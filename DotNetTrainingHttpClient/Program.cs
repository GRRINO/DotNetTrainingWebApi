using System.Threading.Tasks;

namespace DotNetTrainingHttpClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //HttpClientExample clientExample = new HttpClientExample();
            //await clientExample.Read();
            //await clientExample.Edit(1);
            //await clientExample.Edit(999);

            HttpClientBird Bird = new HttpClientBird();
            //await Bird.Read();
            //await Bird.CreatePostAsync(new tblBird { BirdMyanmarName = "ငှက်စိမ်းရင်ဝါ", BirdEnglishName = "Orange-bellied Leafbird", Description = "A beautiful green bird with yellow belly...", ImagePath = "img/1_Orange-belliedLeafbird.jpg" });
            //await Bird.UpdatePostAsync( 0, new tblBird { BirdMyanmarName = "ငှက်စိမ်းရင်ဝါ (ပြင်ဆင်ပြီး)", BirdEnglishName = "Orange-bellied Leafbird (Updated)", Description = "A beautiful green bird with yellow belly... (Updated)", ImagePath = "img/1_Orange-belliedLeafbird.jpg" });
            await Bird.DeletePostAsync( 0 );
        }
    }
}
