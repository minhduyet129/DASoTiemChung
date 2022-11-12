namespace DASoTiemChung.Filter
{
    public class PagedRequestDto
    {
        //Số bảng ghi lấy ra
        public int MaxResultCount { get; set; } = 10;
        //Số page bỏ qua = skipcount -1
        public int SkipCount { get; set; } = 1;
    }
}
