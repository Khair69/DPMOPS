namespace DPMOPS.Services.ServiceRequest.Dtos
{
    public class MapPointDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Title { get; set; }
        public Guid RequestId { get; set; }
        public int StatusId { get; set; }
    }
}
