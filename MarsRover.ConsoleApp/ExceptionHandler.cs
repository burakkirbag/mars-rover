using System;
using MarsRover.Core;

namespace MarsRover.ConsoleApp
{
    public static class ExceptionHandler
    {
        public static void Handle(Exception ex)
        {
            switch (ex)
            {
                case InvalidRoverCommandException invalidRoverCommandException:
                    Handle(invalidRoverCommandException);
                    break;
                case InvalidRoverDirectionException invalidRoverCommandException:
                    Handle(invalidRoverCommandException);
                    break;
                case RoverOutOfBoundaryException roverOutOfBoundaryException:
                    Handle(roverOutOfBoundaryException);
                    break;
                default:
                    Console.WriteLine("Beklenmeyen bir hata ile karşılaşıldı.");
                    Console.WriteLine($"Hata Mesajı : {ex.Message}");
                    Console.WriteLine($"Hata Detayı : {ex.StackTrace}");
                    break;
            }
        }

        static void Handle(InvalidRoverCommandException ex)
        {
            Console.WriteLine("Geçersiz komut girdiniz. Lütfen girmiş olduğunuz bilgileri kontrol ediniz.");
        }

        static void Handle(InvalidRoverDirectionException ex)
        {
            Console.WriteLine("Geçersiz yön girdiniz. Lütfen girmiş olduğunuz bilgileri kontrol ediniz.");
        }
        
        static void Handle(RoverOutOfBoundaryException ex)
        {
            Console.WriteLine("Araç, plato sınırları dışına çıkamaz. Lütfen girmiş olduğunuz bilgileri kontrol ediniz.");
        }
    }
}