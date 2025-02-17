#pragma warning disable CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
using System.Net.Mail;
using System.Net;
using Hotels.Domain.Entities;
using Hotels.Domain.Models;
using Hotels.Domain.Request;
using Hotels.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Hotels.Domain.Response;

namespace Hotels.Infrastructure.Repositories
{
    public class HotelRepository(IHotelContext context) : BaseRepository(context), IHotelRepository
    {
        private readonly IHotelContext _context = context;

        public async Task<long> CreateHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            await SaveChanges();
            return hotel.Id;
        }

        public async Task<long> CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await SaveChanges();
            return room.Id;
        }

        public async Task<bool> IsHotelExists(long hotelId)
        {
            return await _context.Hotels.AnyAsync(x => x.Id == hotelId);
        }

        public async Task<Hotel?> GetHotelById(long hotelId)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.Id == hotelId);
        }

        public async Task<Room?> GetRoomById(long roomId)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);
        }

        public async Task<List<Reservation>?> GetReservationsById(GetResevationRequestDto getReservationRequestDto)
        {
            if (getReservationRequestDto.ReservationId.HasValue)
            {
                return await _context.Reservations.Where(x => x.Room.Hotel.AgencyId == getReservationRequestDto.AgencyId &&
                                                            x.Id == getReservationRequestDto.ReservationId).ToListAsync();
            }
            return await _context.Reservations.Where(x => x.Room.Hotel.AgencyId == getReservationRequestDto.AgencyId).ToListAsync();
        }

        public async Task DeleteHotelById(long hotelId)
        {
            await _context.Hotels.Where(x => x.Id == hotelId).ExecuteDeleteAsync();
        }

        public async Task DeleteRoomById(long roomId)
        {
            await _context.Rooms.Where(x => x.Id == roomId).ExecuteDeleteAsync();
        }

        public async Task<bool> IsRoomExists(long roomId)
        {
            return await _context.Rooms.AnyAsync(x => x.Id == roomId);
        }

        public async Task<List<Hotel>> SearchRooms(GetRoomRequest getRoomRequest) 
        {
            return await _context.Hotels.Where(x => x.IsEnabled && x.City == getRoomRequest.City)
                .Include(x => x.Rooms.Where(x => x.IsEnabled && x.MaxCapacity >= getRoomRequest.NumPeople)).ToListAsync();
        }

        public async Task<long> BookRoom(Reservation reservation) 
        {
            _context.Reservations.Add(reservation);
            await SaveChanges();
            return reservation.Id;
        }

        public async Task SendEmailConfirmation(BookRoomResponse bookRoomResponse)
        {
            try
            {
                // Configuración del cliente SMTP
                SmtpClient client = new SmtpClient("smtp.bookAroom.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("ConfirmaitionMail@bookAroom.com", "travelAdicction123"),
                    EnableSsl = true,
                };

                foreach (GuestDto guest in bookRoomResponse.BookRoomRequest.Guests )
                {
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("ConfirmaitionMail@bookAroom.com"),
                        Subject = "Yey, You have booked your Room!!!",
                        Body = "Confirmación de Reserva\r\n\r\n Estimado/a "+guest.Name+
                        " ,\r\n\r\nLe confirmamos que hemos recibido su reserva para una habitación. Los detalles de su reserva son los siguientes:\r\n\r\nFecha de llegada: "
                        +bookRoomResponse.BookRoomRequest.CheckIn+"\r\nFecha de salida: " + bookRoomResponse.BookRoomRequest.CheckIn + "\r\nNúmero de reserva: "
                        + bookRoomResponse.id + "\r\nEsperamos darle la bienvenida y que su estancia con el hotel sea placentera."
                        + "\r\n\r\nSi tiene alguna pregunta o necesita realizar algún cambio, no dude en contactarnos.\r\n\r\nAtentamente,\r\n\r\n BookARoom.com",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(guest.Email);
                    client.Send(mailMessage);
                }
                
                
                Console.WriteLine("Correos enviados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
#pragma warning restore CA1862 // Use the 'StringComparison' method overloads to perform case-insensitive string comparisons
