using System.Net;
using System.Text.Json.Serialization;

namespace ZACx.Templates.WebApiProject.Core.Common.Concrete
{
    public class ApiResult<T>
    {
        /// <summary>
        /// Dönüşe karar vermek için eklenmiştir. Response modelinin içerisinde görünmemesi için JsonIgnore eklenmiştir.
        /// </summary>
        [JsonIgnore]
        public HttpStatusCode HttpStatusCode { get; set; }
        /// <summary>
        /// Toplam 6 karakter ile sınırlıdır. İlk 3 karakter(XXX) http method statü'lerine karşılık gelmektedir.Sonraki 3 karakter(YYY) proje özelinde kullanılmış koda denk gelmektedir. Default Custom Code(YYY): 000'dır.
        /// </summary>
        public string MessageCode { get; set; }

        /// <summary>
        /// İstek içerisinde yer alan dil parametresine uygun Türkçe, İngilizce veya farklı bir dilde genel bilgilendirme mesajına karşılık gelir.
        /// </summary>
        public string InternalMessage { get; set; }

        /// <summary>
        /// İstek içerisinde yer alan dil parametresine uygun Türkçe, İngilizce veya farklı bir dilde bilgi mesajına karşılık gelir. Kısacası kullanıcı tarafına gösterilecek mesajı kapsar.
        /// </summary>
        public string UserMessage { get; set; }

        /// <summary>
        /// Bulk işlemlerde hata oluşması durumunda bilgi dönülmesi gerektiği durumlarda kullanılmaktadır. Bu bilgi TModel içerisinde de yer alabilir. İhtiyaç dahilinde konumlandırılması yazılımcıya bırakılmıştır.
        /// </summary>
        public List<string>? Errors { get; set; }

        /// <summary>
        /// Servis tarafında dönüşü yapılacak veriyi kapsamaktadır.
        /// </summary>
        public T Data { get; set; }
    }
}
