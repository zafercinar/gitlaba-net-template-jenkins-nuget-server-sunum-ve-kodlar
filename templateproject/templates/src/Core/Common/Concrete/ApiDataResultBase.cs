namespace ZACx.Templates.WebApiProject.Core.Common.Concrete
{
    public abstract class ApiDataResultBase
    {
        /// <summary>
        /// Mevcut sayfadaki kayıt sayısını ifade etmektedir.
        /// </summary>
        public int? CurrentPageDataCount { get; set; }

        /// <summary>
        /// Toplam kayıt sayısını ifade etmektedir.
        /// </summary>
        public int? TotalDataCount { get; set; }

        /// <summary>
        /// Sıralama için asc/desc kullanılmaktadır.
        /// </summary>
        public string? Sorting { get; set; }

        /// <summary>
        /// Mevcut sayfayı ifade etmektedir.
        /// </summary>
        public int? CurrentPageNumber { get; set; }

        /// <summary>
        /// Toplam sayfa sayısını ifade etmektedir.
        /// </summary>
        public int? TotalPageNumber { get; set; }

    }
}
