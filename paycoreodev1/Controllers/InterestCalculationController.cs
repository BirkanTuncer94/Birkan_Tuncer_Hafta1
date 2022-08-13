using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PayCoreHomeWork1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestCalculationController : ControllerBase
    {
        public InterestCalculationController()
        {

        }

        [HttpGet] // Yalnız bir adet get olduğu için isimlendirme yapmıyorum.
        public ActionResult CompoundInterest([FromQuery] double mainMoney, int time, double interestRate) // Birden fazla parametre olduğu için FromQuery kullandım.
        {
            Interest interest = new Interest();
            interest.totalBalance = mainMoney * Math.Pow((1 + interestRate), time); // Bileşik faiz formülü.
            interest.interestAmount = interest.totalBalance - mainMoney; // Faizin kazandırdığı miktar.
                                                                         //

            // ↓ Görsel olarak daha güzel durması için virgülden sonra 3 rakam alıyorum ↓ //
            interest.totalBalance = Math.Round(interest.totalBalance, 2);
            interest.interestAmount = Math.Round(interest.interestAmount, 2); //

            if (mainMoney < 0 || time < 0) // Anapara veya zaman negatif olamayacağı için kontrolünü yapıyorum.
            {
                return BadRequest(); //400
            }


            return Ok(interest); // Verilen değerlerde bir problem yoksa istenilen tipte veriyi döndürüyorum.

        }

        public class Interest
        {
            public double totalBalance { get; set; }
            public double interestAmount { get; set; }

        }
    }

}


