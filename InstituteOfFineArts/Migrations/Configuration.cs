namespace InstituteOfFineArts.Migrations
{
    using InstituteOfFineArts.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<InstituteOfFineArts.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(InstituteOfFineArts.Models.ApplicationDbContext context)
        {
            // context.Database.ExecuteSqlCommand("DELETE FROM Submissions");
            // context.Submissions.AddOrUpdate(
            //     new Submission(04,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranh3dntp.com/wp-content/uploads/2018/10/tranh-phong-canh-dong-que.jpg",
            //         "Làng quê em",
            //         "Tranh làng quê em, nơi em sinh ra và lớn lên.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
            //         ,
            //     new Submission(
            //             04,
            //             "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //             "https://tranhphongcanhdep.com.vn/wp-content/uploads/2018/08/tranh-phong-canh-son-dau-son-thuy-huu-tinh-kho-lon-Amia-394.jpg",
            //             "Tiên Cảnh",
            //             "Tranh Tiên cảnh nơi núi rừng",
            //             DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://scontent.subi.vn/cmsmedia/tranh-ve-phong-canh-que-huong-cua-hoc-sinh-cap-2-luon-luon-an-tuong-8b8a9893505d6f2505b393aa500dbb73.jpg",
            //         "Làng quê Việt Nam",
            //         "Tranh làng quê Việt Nam những năm 2000",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://bantranh.com/wp-content/uploads/2019/06/tranh-son-dau-cay-da-ben-nuoc-san-dinh.jpg",
            //         "Cây đa làng em",
            //         "Cây đa cổ thụ làng em",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://tranhtrangtri360.com/wp-content/uploads/2019/03/up1-tranh-phong-canh-pho-co-ha-noi-1.jpg",
            //         "Phố cổ",
            //         "Phố cổ Hà Nội",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://katahome.com/wp-content/uploads/2018/11/bi-quyet-lua-chon-tranh-phong-canh-dep-treo-o-phong-khach.jpg",
            //         "Làng chài",
            //         "Tranh làng chài, nơi em sinh ra và lớn lên.",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://tranhphongcanhdep.com.vn/wp-content/uploads/2018/07/tranh-phong-canh-que-huong-lang-que-viet-nam-Amia-358.jpg",
            //         "Bui tre",
            //         "Tre giúp dân ta chống giặc ngoại xâm",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://tranhtreotuongamia.com/wp-content/uploads/2018/10/buc-ve-tranh-phong-canh-don-gian-danh-cho-hoc-sinh-11.jpg",
            //         "Thuyền và biển",
            //         "Lênh đênh trên con thuyền",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://tranhphongcanhdep.com.vn/wp-content/uploads/2018/09/tranh-phong-canh-que-huong-dep-cong-dinh-goc-da-Amia-TSD-395.jpg",
            //         "Cổng làng quê em",
            //         "Cổng làng quê em, nơi vui đùa của đám trẻ trong làng",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         04,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://miro.medium.com/max/700/0*KesfreB2-wXR_pvV.jpg",
            //         "Cánh đồng",
            //         "Cánh đồng lúa quê em.",
            //         DateTime.ParseExact("2020-03-06", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(06,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhsondaunghethuat.com.vn/wp-content/uploads/2018/06/tranh-son-dau-tinh-vat-mau-01-1.jpg",
            //         "Nho và Rượu",
            //         "Rượu được làm từ nho",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
            //         ,
            //     new Submission(
            //             06,
            //             "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //             "https://www.tranh-dep.com/images/stories/virtuemart/product/tranh-son-dau-tinh-vat.jpg",
            //             "Lọ Hoa Cúc",
            //             "Tranh hoa cúc",
            //             DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://bantranh.com/wp-content/uploads/2019/03/74B0CC76-C2A0-4E88-BD3A-99DB1D5AC8EF.jpeg",
            //         "Cúc trắng",
            //         "Hoa cúc trắng",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://i.pinimg.com/474x/ec/c5/14/ecc514b362e106cadb0624bece59bdd2.jpg",
            //         "Hoa sen",
            //         "Lọ hoa sen",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://lh3.googleusercontent.com/proxy/lPPZDPxLwEZCsyYnMmMC_kz-NARumfT4DZ_xyg6DMQ9zbt-IkOHQ3uxrncBbwEdmCHZzhburt8f9IeTJvuiD5Aqk0w5sWtrXRof180l8UvPVYRt_uoU4oMQgx00pYaehvyQjiiJ5MmTTfhcV4TiXvICSIvPRiMdu86aRc1oydmxHK1kLaHpBwQrLXPoGPZMluyFRm9Wan5OmTHFp8_yz9tTiZDoWPas9cVuBXfyBB4va-CF66qF1MsRFXJ5DjzaD16Z5vN8sJ4RQWkN4zIoxJqw",
            //         "Hoa hướng dương",
            //         "Lọ hoa hướng dương",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://artminhson.com/wp-content/uploads/2018/04/Oil-painting-other-32.jpg",
            //         "Hoa chuối",
            //         "Hoa chuối và quả chuối",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://bantranh.com/wp-content/uploads/2019/07/FB_IMG_1564114554591.jpg",
            //         "Hoa loa kèn",
            //         "Lọ hoa loa kèn",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://lh3.googleusercontent.com/proxy/5LifPgj4YnORwnRU7MoXCzRhFH3NwVxqdkH1555qm109URcR6vBKbClwIQhxxjsqPVNTtl2nfFAS_DvkITjFDEbnUf9UvTxaTYGzBRYwEFqUgGC90vX01Xd_LHSsJ-mWsHM",
            //         "Đĩa dâu tây",
            //         "Đĩa dâu tây và bình nước",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://lh3.googleusercontent.com/proxy/r735pzB1tOJWZ9qzcS_6_jRbcaj5wbi3l_ibPhqP8CZ_iNkhQxmi_DmPrH6dQUZYDVQnr7SRygtAqQzz4KYkumRH5nysnuSluamLkNXaOBsb4og1HHNezoNo677PiFApkdjrVi1L9RTLwtCrQ1pmlFSXWWcYOP3skEQGT_gFE4ogwXmK1bR1LLEkQAuaQw",
            //         "Nón lá",
            //         "Chiếc nón lá",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         06,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://namphuonggallery.vn/public/admin/ckfinder/userfiles/images/tranh-tinh-vat-dep1.jpg",
            //         "Rượu nho",
            //         "Rượu nho và quả nho",
            //         DateTime.ParseExact("2020-03-08", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(08,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.tuoitre.vn/thumb_w/640/2018/3/11/dogs-poker-read-only-1520739677346916922460.jpg",
            //         "Những chú chó",
            //         "Những chú chó đang đánh bài",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
            //         ,
            //     new Submission(
            //             08,
            //             "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //             "https://tranhsondauart.vn/images/virtuemart/product/3912.jpg",
            //             "Cặp song sinh chó",
            //             "Cặp song sinh chó",
            //             DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://lh3.googleusercontent.com/proxy/BLGEW9KNVrZ5WAyh9yo71Blwqglhdnt_EQ5urcAPFRVricjjh7iAUh7aBH6r3o23g9RIbhDF2quXnq5Hp4k_lNaFV_dvzudb_x_ECCkEFax3ncQ1TgNdwGGTIeSGeohEXtXw",
            //         "Chú chó golden",
            //         "Chú chó gâu đần",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://lh3.googleusercontent.com/proxy/GusKfKDgoqzK9hWlhm2QbL2RT4heSOAfzV6-yE9ishGX1xKg0ojZasteMFFykmIyHkvOaDnwL78sYVNWNNOgFsYFl_i75U7VkcFF9tocrE-gu2Vm2qk7X3vraw5rP3fPR_Lk90bD5akgOgCE-W2mLw",
            //         "Chú chó pug",
            //         "Chú chó mặt mâm",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://cdn.tuoitre.vn/thumb_w/640/2018/2/8/logo-8-2-hoa-si-hue-ve-tranh-cho-5-1518089695215227717074.jpg",
            //         "Chú chó chăn cừu",
            //         "Chú chó sau hàng thép gai",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://bautroitranhdep.com/images/stores/2015/07/25/tranh_son_dau_%C4%91ong_vat%20(38).jpg",
            //         "Chó và mèo",
            //         "Đôi bạn thân chó và mèo",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://cdn.tuoitre.vn/thumb_w/640/2018/17-tinh-ban-hoa-si-do-cuong-1516402594773.jpg",
            //         "Chó và bé",
            //         "2 chú chó xinh xắn và em bé",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://cdn.tuoitre.vn/2018/9-tac-pham-hoa-mai-hoa-si-phan-minh-nhat-1516402652063.jpg",
            //         "Chú chó đốm",
            //         "Chú chó đốm ngậm cành hoa",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://cdn.tuoitre.vn/thumb_w/640/2018/10-tac-pham-cau-chuyen-dau-nam-hoa-si-thai-vinh-thanh-1516402879777.jpg",
            //         "Tám chú chó",
            //         "Tám chú chó gâu đần",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         08,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://img.idesign.vn/2018/02/22/69749/iD_%C4%91uongaihoatranhdongho_12-1.jpg",
            //         "2 chú chó",
            //         "2 chú chó theo phong cách tranh đông đồ",
            //         DateTime.ParseExact("2020-03-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(10,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://yeutranh.vn/wp-content/uploads/2018/11/unnamed-2-1024x794.jpg",
            //         "Ngôi đền",
            //         "Ngôi đền của những giấc mơ",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
            //         ,
            //     new Submission(
            //         10,
            //             "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //             "https://drive.tinhhoa.net/cache/http/original/2018/03/10/tinhhoa.net-/Q5UNs3-20180310-10-buc-tranh-ton-giao-xuat-sac-thoi-ky-phuc-hung.jpg",
            //             "Sân Phục hưng",
            //             "Sân rất nhiều người đến chơi",
            //             DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://inuvhieuhuyen.vn/wp-content/uploads/2018/12/tranh-phuc-hung-2.jpg",
            //         "Mẹ và con",
            //         "Các mẹ và các con",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://www.dkn.tv/wp-content/uploads/2017/03/Ch%C3%BAa-t%E1%BA%A1o-adam-2.jpeg",
            //         "Adam và chúa",
            //         "Adam và chúa người tạo ra muôn loài",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://vuongquoctranh.com/files/news/172/images/35-buc-tranh-thoi-ky-phuc-hung-noi-tieng-toan-the-gioi-5.jpg",
            //         "Đức mẹ đồng chinh",
            //         "Đức mẹ đồng chinh và những người dân",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://mb.dkn.tv/wp-content/uploads/2015/10/tranh-phuc-hung-giac-mo-590x308.jpg",
            //         "Nhạc sĩ trẻ",
            //         "Nhạc sĩ và những loại nhạc cụ",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://baoquocte.vn/stores/news_dataimages/phamthuan/062017/03/10/104927_FullSizeRender_20.jpg",
            //         "Người đẹp",
            //         "Chân dung người đẹp nước ý",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://mb.dkn.tv/wp-content/uploads/2019/08/untitled-1-158.jpg",
            //         "Nhân mã",
            //         "Nhân mã và những người dân thường",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://nghethuattranhtuong.vn/upload/user/images/2547872.jpg",
            //         "Người và cừu",
            //         "Đôi vợ chồng và chú cừu con",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         10,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://vuongquoctranh.com/files/news/172/images/35-buc-tranh-thoi-ky-phuc-hung-noi-tieng-toan-the-gioi-6.jpg",
            //         "Nàng Mona Lisa",
            //         "Chân dung nàng Mona Lisa",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(12,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://lh3.googleusercontent.com/proxy/jG4V1YtL47OD5feFNB8K5EByyS8U81LkAq4lKatmioMTDadhuG2PtqNFnisgjJlv-gLLesK20_TQjs6uSKti6ubtnxz_0D-lb3URjiIVGeYjvpYVM0J7ITfEtOxFDh80pHb0DiO2VUv16CKI39tZ5Js41h6dJRwUFVL3be2JPQ2zF5uU6nFrX7OPeYTzxd4UhK87ROTzl_beeuL8RQlMSjAov79I1v8BR1LACpbLl3ByVA",
            //         "Núi non",
            //         "Tranh thủy mạc núi non",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture))
            //         ,
            //     new Submission(
            //         12,
            //             "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //             "https://nghethuatxua.com/wp-content/uploads/2016/04/tranh-thuy-mac-8.jpg",
            //             "Sơn Miếu",
            //             "Sơn miếu trên núi",
            //             DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://kientrucsuvietnam.vn/wp-content/uploads/2019/04/lunatm0105-5314.jpg",
            //         "Hạc tiên",
            //         "Những chú hạc trong truyền thuyết",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://tranhphuquang.com/admin/sanpham2/phongthuy/R0056.jpg",
            //         "Non nước",
            //         "Núi non sông nước, phong cảnh hữu tình",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://thegioitranhsondau.com/upload/sanpham/large/tranh-thuy-mac-cay-tung-tren-dinh-thac-hung-vi.jpg",
            //         "Cây tùng",
            //         "Cây tùng trên đỉnh thác hùng vĩ.",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://tamthuan.com/wp-content/uploads/2016/09/ngh%E1%BB%87-s%C4%A9-v%E1%BA%BD-tranh-thu%E1%BB%B7-m%E1%BA%B7c-1-1024x538.jpg",
            //         "Trúc và chim",
            //         "Rừng trúc và bầy chim",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://2.bp.blogspot.com/-Lpi36PF8eqQ/VcBU93GazuI/AAAAAAAAAG0/SFyP5XJpAig/s1600/TranhThuyMac.jpg",
            //         "Căn nhà",
            //         "Căn nhà mộc mạc trên núi",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://inuvhieuhuyen.vn/wp-content/uploads/2018/12/son-thuy-TQ-4.jpg",
            //         "Vạn lý trường thành",
            //         "Vạn lý trường thành và bầy hạc tiên",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://nghethuatxua.com/wp-content/uploads/2016/04/tranh-thuy-mac-10-1.jpg",
            //         "Hoa Mai",
            //         "Hoa Mai và những chú chim non",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         12,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://sackim.com/wp-content/uploads/2019/12/tranh-thuy-mac-thuong-co-2-mau-chu-dao-mau-trang-va-the-hien-tam-tu-cua-con-nguoi.jpg",
            //         "Những chú hạc tiên",
            //         "Hạc tiên bay theo đàn và sông núi hữu tình",
            //         DateTime.ParseExact("2020-07-20", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)),
            //     new Submission(
            //         05,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://img.cdn9h.com/article/2019_1_w3/488-buc-tranh-dam-cuoi-chuot-voi-net-ve-hai-huoc-di-dom.jpeg",
            //          "Tranh Đám cưới chuột",
            //          "Nói đến Tranh Đông Hồ, chắc hẳn không ai không biết đến bức tranh nổi tiếng “Đám cưới chuột”. Bức tranh này được khắc họa sinh động, nét vẽ ngộ nghĩnh đậm chất dân gian với ngụ ý sâu xa, nhắc nhở con người ta nên sống cho phải đạo, biết đối nhân xử thế, sống nhân hậu, nhân văn nhưng vẫn kiên cường, luôn sẵn sàng, tràn đầy sức chiến đấu.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         05,
            //         "f6b4adf4-a976-4cdd-940e-4c2b87b5fa41",
            //         "https://img.cdn9h.com/article/2019_1_w3/488-vinh-quy-bai-to-the-hien-nhung-dao-ly-quy-bau-tu-ngan-doi-nay-cua-dan-toc-ta.jpeg",
            //          "Tranh Vinh quy bái tổ",
            //          "Đây là một trong số những bức tranh được nhiều người yêu thích nhất của làng Tranh Đông Hồ bởi nét đẹp ý nghĩa mà bức tranh truyền tải. Đó là sự vinh danh những con người tài giỏi đỗ đạt, vinh danh người thầy, người cha mẹ, làng xóm có công nuôi dưỡng, dạy dỗ người tài. Qua đây, ta có thể thấy được truyền thống “tôn sư trọng đạo”, “Công cha, nghĩa mẹ, ơn thầy”. Những đạo lý quý báu, dù ngàn năm sau vẫn luôn luôn bền vững giá trị trong lòng người Việt.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         05,
            //         "08e347c9-bc98-4726-872d-40c0eeab8258",
            //         "https://img.cdn9h.com/article/2019_1_w3/488-cap-tranh-vinh-hoa-phu-quy-voi-y-nghia-cau-mong-su-may-man-phu-quy.jpeg",
            //          "Tranh Vinh hoa phú quý",
            //          "“Vinh hoa phú quý” là bức tranh được yêu thích xếp thứ ba bởi nó mang nhiều ý nghĩa tốt lành, may mắn, đó là sự chúc tụng, cầu may cho gia đình được đầy đủ vinh hoa phú quý, con đàn cháu đống, cả nếp cả tẻ. Thể hiện sự tròn đầy, viên mãn, hạnh phúc vô biên.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         05,
            //         "f4fff052-8aed-4141-be36-2fdbd6035ea5",
            //         "https://img.cdn9h.com/article/2019_1_w3/488-dan-ga-me-con-la-buc-tranh-the-hien-su-cau-mong-hanh-phuc-am-no.jpeg",
            //          "Tranh đàn gà mẹ con",
            //          "“Đàn gà mẹ con” cũng là một bức tranh nổi tiếng thường được mọi người treo trang trí trong nhà với mong muốn cầu chúc sự bình an, vô sự cho gia đình, mong cho gia đình được con cháu đuề huề, vợ chồng sớm có con, viên mãn hạnh phúc.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         05,
            //         "87a00780-5e6f-4d17-b63a-6e6761ef854f",
            //         "https://www.safav.com.vn/wp-content/uploads/2018/02/%E1%BA%BEch-%C4%91i-h%E1%BB%8Dc.jpg",
            //          "Tranh Thầy Đồ Cóc",
            //          "Tranh “Thầy đồ cóc” là một bức tranh nổi tiếng thể hiện ý nghĩa chúc tụng, thường được mọi người tặng cho các cháu nhỏ hay các em học sinh để chúc sự siêng năng, ham học hỏi, thông minh sáng dạ trong học tập.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         05,
            //         "a0d09534-69e8-4cd8-9da8-bbcf5a122349",
            //         "https://nhaxinhcenter.com.vn/source/pic/tin-tuc/tranh-dong-ho/muc-dong-93342.jpg",
            //          "Tranh Chăn Trâu Thổi Sáo",
            //          "Tranh “Chăn trâu thổi sáo” hay còn gọi là “Mục đồng thổi sáo” là một bức tranh thể hiện sự yên bình, thanh lạc trong cuộc sống. Đó là cuộc sống nơi làng quê mộc mạc, giản dị, bình yên mà mọi người thường mong muốn được sống.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         05,
            //         "8d180993-d4c8-4ca6-984c-01b8cfa48428",
            //         "https://vanhoadoisong.vn/file/thumb/500/735351710.jpg",
            //          "Tranh Mẹ Con Đàn Lợn Âm Dương",
            //          "“Lợn đàn” hay “Mẹ con đàn lợn âm dương” là một cái tên quen thuộc với nhiều người, từng được nhà thơ Hoàng Cầm nhắc đến trong bài thơ “Bên kia sông Đuống”. Bức tranh là sự thể hiện sự sung túc, ấm no, viên mãn, con đàn cháu đống cùng quây quần, hạnh phúc bên nhau, cho tình cảm thêm gắn bó, sâu sắc. Ngoài ra, bức tranh còn là sự gợi nhớ về quê hương, về tuổi thơ, nơi “chôn nhau cắt rốn” của mỗi con người.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         05,
            //         "db4f2629-6004-4ee0-aae5-7b260f030372",
            //         "https://2.bp.blogspot.com/-wUyEVBVCr6A/Wn8EKs1DuYI/AAAAAAAADhM/etB4Mv5PpGYTOWkeLd2IZ6qQQu_MtAv5wCLcBGAs/s1600/H%25E1%25BB%25A9ng%2Bd%25E1%25BB%25ABa.jpg",
            //          "Tranh Hứng Dừa",
            //          "Hứng dừa” là một bức tranh nổi tiếng thể hiện sự hòa hợp, hạnh phúc của một gia đình Việt Nam. Dù mưa nắng, bão lũ, đất đai khô cằn, con người vẫn luôn vươn lên, sống hạnh phúc, vui vẻ, ấm no, hòa thuận, vượt qua mọi khó khăn trở ngại. Trong bức tranh, ta có thể thấy người đàn ông, người trụ cột trong gia đình, biết dũng cảm trèo lên cao, tượng trưng cho đỉnh cao của danh vọng để đem đến hạnh phúc, tiếng cười cho vợ con. Cho thấy một ý nghĩa sâu xa đằng sau những nét vẽ mộc mạc, giản dị.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         05,
            //         "b328957f-b912-4908-a142-f613da8ce8d3",
            //         "https://media.ohay.tv/v1/upload/content/2018-02/06/29459-ed05bb7e6b0a33ffd3e3267ffb84dbf6-ohaytv.jpg",
            //          " Tranh Lễ trí - Nhân nghĩa",
            //          "“Lễ trí - Nhân nghĩa” là cặp tranh nổi tiếng của làng Tranh Đông Hồ với ngụ ý cầu cho bé gái lớn lên chăm chỉ, nhu mì, hiền dịu, xinh đẹp như con rùa, còn người con trai thì giỏi giang, học hành hiển đạt. Ngoài những ý nghĩa trên, hình ảnh con cóc còn gợi nhớ cho mọi người đến hình ảnh con cóc dũng cảm, dám lên trời kiện để cầu mưa cho dân làng.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //        new Submission(
            //         05,
            //         "c92550e7-bbb9-4429-98da-8c661bdd3835",
            //         "https://lh3.googleusercontent.com/proxy/3W28e7NWC4gt-mFJBbjlJ9_2IlBTzZMv8ucHQAFGB6S4jE5_bxC9yomLM8NugT5J5w53Cw_Y84cZwYiPtpqUDW_4v_eXpvPpeHs58QpTk6W1jgQ_1iWSlGa_hPADgQFZ",
            //          "Tranh Đu Quay",
            //          "“Đu quay” là một bức tranh khắc họa nét đẹp văn hóa trong nếp sinh hoạt của người Việt xưa. Qua bức tranh, ta thấy được sự hòa hợp, êm ấm của con người, cầu mong sự hòa thuận của ông trời để thời tiết luôn yên lành, mùa màng bội thu, tình yêu đôi lứa trọn vẹn.",
            //         DateTime.ParseExact("2020-03-07", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://thegioitranhsondau.com/upload/sanpham/tranh-ve-bien-va-binh-minh-tuyet-dep.jpg",
            //          "Tranh Thuyền Và Biển Lúc Bình Minh",
            //          "Tranh thuyền và biển lúc mình minh",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://salt.tikicdn.com/ts/tmp/06/11/c8/6be91ff4d83623d6e18a59b444c09bc0.jpg",
            //          "Tranh Thuyền Buồm Lúc Hoàng Hôn",
            //          "Tranh thuyền và biển lúc hoàng hôn",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhphuquang.com/admin/sanpham/B0272_8098_anh1.jpg",
            //          "Tranh Thuyền Buồm Và Hải Âu",
            //          "Tranh thuyền buồm và những chú chim hải âu",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://shop.artfido.com/auctions/467c88e2-36e1-412a-875d-dbddf58b0b60220435/large//1439948675_Touch_of_horizon.jpg?t=3",
            //          "Tranh Thuyền Buồm Xế Chiều",
            //          "Tranh thuyền buồm và biển vào một buổi chiều thu ",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://thegioitranhsondau.com/upload/sanpham/large/tranh-thuyen-buom-va-song-bien-lan-tan.jpg",
            //          "Tranh Thuyền Và Sóng Biển",
            //          "Tranh thuyền và sóng biển",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhsondaudepamia.com/wp-content/uploads/2017/01/tranh-son-dau-thuan-buom-xuoi-gio.jpg",
            //          "Tranh Thuận Buồm Xuôi Gió",
            //          "Tranh thuận buồm xuôi gió",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://thegioitranhsondau.com/upload/sanpham/large/tranh-thuyen-buom-va-hoang-hon-tren-bien.jpg",
            //          "Tranh Thuyền Và Hoàng Hôn",
            //          "Tranh thuyền buồm và hoàng hôn trên biển đầy thơ mộng",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhsondaunghethuat.com.vn/wp-content/uploads/2016/09/thuyen-truoc-hoang-hon-1.jpg",
            //          "Tranh Thuyền Buồm",
            //          "Tranh thuyền buồm vào buổi chiều êm ả",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhdepgiare.vn/upload/product/thuyen-43-5396.jpg",
            //          "Tranh Thuyền Nhỏ",
            //          "Tranh thuyền buồm nhỏ",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //         new Submission(
            //         07,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://img4.thuthuatphanmem.vn/uploads/2019/12/22/buc-tranh-thuyen-buom-son-dau-rat-dep_013835367.jpg",
            //          "Tranh Thuyền Nhỏ Và Biển",
            //          "Tranh chiếc thuyền nhỏ vươn mình ra biển lớn",
            //         DateTime.ParseExact("2020-03-09", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //
            //
            //          new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://2sao.vietnamnetjsc.vn/images/2018/12/12/21/05/tranh-phong-thuy-1.jpg",
            //          "Tranh Sơn Thủy",
            //          "Núi thể hiện sự vững vàng, chắc chắn, nước chảy thể hiện sự bình an, cũng là dấu hiệu của tài lộc. Nước vây quanh núi, được thế núi vững vàng bảo trợ nên tiền bạc không lo cạn kiệt, chẳng sợ thất thoát. Theo phong thủy phòng khách, đây sẽ là bức tranh may mắn lý tưởng đó.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://2sao.vietnamnetjsc.vn/images/2018/12/12/21/05/tranh-phong-thuy-2.jpg",
            //          "Tranh Hoa Đào",
            //          "Hoa đào tượng trưng cho hơi thở của mùa xuân, những bức tranh phong thủy hoa đào sẽ khiến cho không gian căn phòng thêm phóng khoáng, rộng mở, hài hoà và tao nhã. Không những thế hoa đào còn là biểu tượng của cuộc sống, là loài cây cân bằng các nguồn năng lượng Âm Dương trong trời đất, mang lại sự hài hoà và thành công. Bên cạnh đó treo tranh phong thủy hoa đào trong phòng khách còn mang ý nghĩa cầu mong may mắn, sức khoẻ và thể hiện sự tinh tế, cân bằng tâm trạng con người.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://2sao.vietnamnetjsc.vn/images/2018/12/12/21/06/tranh-phong-thuy-3.jpg",
            //          "Tranh Cá Chép",
            //          "Trong phong thủy, cá tượng trưng cho sự no ấm, đủ đầy và bức tranh thường về cá là “Cửu ngư quần hội” với hình ảnh chín chú cá vàng vây quanh hoa sen hoặc hoa mẫu đơn. Bức tranh tượng tương cho sự dư dả, sung túc. Không những thế cá chép là biểu tượng của sự kiên trì, bền bỉ và tranh cá chép mang ý nghĩa về sự thăng tiến công danh và nổi tiếng.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://atuongdep.com/wp-content/uploads/2017/07/C%C3%A2y-Tre-trong-phong-th%E1%BB%A7y.jpg",
            //          "Tranh Cây Tre",
            //          "Cây tre không chỉ là biểu tượng của trường thọ và sức khỏe, mà còn là biểu tượng mạnh mẽ của tài lộc. Đồng thời cây tre cũng là biểu tượng của tính kiên cường vượt qua mọi nghịch cảnh và khả năng chống chọi với sóng gió của cuộc đời.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://lh3.googleusercontent.com/proxy/jGFh-pixKgwCFjXa9fCBLkRzBOK90FmM9KjxW33fu1Cjgcswn5W3GVdRsb8NF2ao041X_fGKgs6voD_qO8z2Enu_YQyaH5-kQJXAaE7VuRMwNxlvDnU_ZAx22UAqdoargwyRBLWkJptT63Ht6SK8BIE8IFY",
            //          "Tranh Hoa Mẫu Đơn",
            //          "Hoa mẫu đơn với vẻ đẹp viên mãn, rực rỡ thể hiện cho sự giàu có cùng những điều an lành cho gia chủ. Theo phong thủy cuối năm, 1 bức tranh hoa mẫu đơn treo trong nhà sẽ có tác dụng hóa giải tình trạng thiếu hụt tiền bạc của gia chủ 1 cách dễ dàng. Để đạt được hiệu quả tốt hơn thì đừng tùy tiện treo tranh ở bất cứ nơi nào bạn thích mà hãy xem đến hướng treo phù hợp.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://bantranh.com/wp-content/uploads/2019/04/tranh-con-cong.jpg",
            //          "Tranh Con Công",
            //          "Công phượng là biểu tượng cho sự thăng hoa trong cuộc sống và thăng tiến trong công việc , những bức tranh công phượng khi treo hoặc dán tường phòng khách mang đến sự sang trọng và đẹp mắt.",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://tranhdantuongvietnam.com/wp-content/uploads/2018/11/tranh-phong-thuy-19-600x424.jpg",
            //          "Tranh Non Nước",
            //          "Tranh phong thủy non nước hữu tình",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://phongthuycoban.com/wp-content/uploads/2016/12/tranh-thuan-buon-xuoi-gio-cho-nguoi-menh-thuy.jpg",
            //          "Tranh Thuận Buồm Xuôi Gió",
            //          "Tranh thuận buồn xuôi gió mang may mắn",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://northinterior.vn/img/4-tranh-phong-thuy-cho-nguoi-menh-Hoa-may-man-4.jpg",
            //          "Tranh Làng Quê",
            //          "Tranh phong thủy làng quê việt",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //        new Submission(
            //         09,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://northinterior.vn/img/11-buc-tranh-phong-thuy-cho-nguoi-menh-Hoa-11.jpg",
            //          "Tranh Phong Thủy Rồng ",
            //          "Tranh phong thủy rồng đại diện cho sức mạnh và quyền lực",
            //         DateTime.ParseExact("2020-06-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //     new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://drive.tinhhoa.net/cache/http/original/2016/10/20/tinhhoa.net-/Oz9LJZ-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Em Đọc Sách",
            //          "Tranh hai anh em ngồi đọc sách bên suối ",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/BLAurg-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Bé Và Hoa",
            //          "Tranh em bé và bông hoa",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/Qo71M8-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Bé Hái Hoa",
            //          "Tranh em bé hái hoa",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/5rGXyd-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Tình Bạn",
            //          "Tranh bé nằm ngủ ngoan",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/ZDiUrW-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Anh Em Sinh Đôi",
            //          "Tranh hai anh em sinh đôi ngồi cạnh biển",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/V0ywFr-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Bé Yêu Hoa",
            //          "Tranh bé và những bông hoa thơm ngoài vườn",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "http://drive.tinhhoa.net/http/1200x1200/tinhhoa.net-/yEbdk5-20161020-15-buc-tranh-son-dau-ve-tre-em-tuyet-dep.jpg",
            //          "Tranh Bé Và Gia Đình Vịt",
            //          "Tranh bé và gia đình nhà vịt con",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://lh3.googleusercontent.com/proxy/5AvxfoMvtLJyewmxV5SZpAvhsR6g0_TWEXQ51lA5JSrM9QUG1WPaRcL7YjsCcOf1ZPNot9OF5qx4jlsYjtSn5l3E4paiVD6_MkCO2el_s3pZIdqx4jj3b_6eYFcT",
            //          "Tranh Bé Và Bướm Nhỏ",
            //          "Tranh bé và chú bướm nhỏ",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://langhue.org/lh-files/2014-04/TranhDonaldZolan_HVH_4.jpg",
            //          "Tranh Bé Và Mèo Con",
            //          "Tranh bé vui vẻ ôm mèo con",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //         new Submission(
            //         11,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://langhue.org/lh-files/2014-04/TranhDonaldZolan_HVH_2.jpg",
            //          "Tranh Bé Ngây Ngô",
            //          "Tranh bé ngay ngô ",
            //         DateTime.ParseExact("2020-04-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //         new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/Oil_Painting_Style_Full_Square_Drill_Turtle_5D_DIY_Diamond_Painting_Kits_UK_NA0881_2048x2048_aee6dd40-20b9-451d-93ae-d4bbc1300cf4_750x.jpg?v=1571722005",
            //          "Tranh Rùa Và Biển",
            //          "Tranh rùa bơi giữa đại dương bao la",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-087_750x.jpg?v=1571721962",
            //          "Tranh Cá Heo",
            //          "Tranh hai chú cá heo ",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-291_750x.jpg?v=1571721962",
            //          "Tranh Cá Heo Vượt Sóng",
            //          "Tranh những chú cái heo vượt sóng",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-343_540x.jpg?v=1571721962",
            //          "Tranh Cá Heo Và Hoàng Hôn",
            //          "Tranh cá heo và chiều hoàng hôn tuyệt đẹp",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/pbn30248_750x.jpg?v=1572507478",
            //          "Tranh Sao Và Ốc Biển",
            //          "Tranh sao và ốc biển",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/pbn30252_750x.jpg?v=1571721948",
            //          "Tranh Cá Mập",
            //          "Tranh cá mập hung dữ",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //      new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-424_750x.jpg?v=1571721962",
            //          "Tranh Cá Voi",
            //          "Tranh cá voi khổng lồ",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/Full_Square_Drill_Seahorse_5D_Diy_Embroidery_Cross_Stitch_Diamond_Painting_Kits_UK_NA0308_2048x2048_980f6b17-b47b-4486-9f59-47a86819a191_2048x2048.jpg?v=1571722002",
            //          "Tranh Cá Ngựa",
            //          "Tranh cá ngựa",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //       new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-1622-__vectorized_750x.png?v=1571721971",
            //          "Tranh Rùa Con",
            //          "Tranh rùa con giữa biển khơi",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         ),
            //         new Submission(
            //         13,
            //         "31312b37-c909-44ec-99cf-948d5899517a",
            //         "https://cdn.shopify.com/s/files/1/0249/8356/8437/products/WM-923_750x.png?v=1571721902",
            //          "Tranh Rùa Và Cá",
            //          "Tranh Rùa và những sinh vật biển",
            //         DateTime.ParseExact("2020-07-19", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)
            //         )
            // );
        }
    }
}
