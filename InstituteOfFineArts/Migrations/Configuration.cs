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
            context.Competitions.AddOrUpdate(
                new Competition(
                01,
                "We are the peoples we the arts 2018",
                DateTime.ParseExact("2017-12-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2018-06-18", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster1.jpg",
                "1st prize: 1000$; 2nd prize: 500$; 3rd prize: 200$",
                "We the Peoples,We the Arts is an art competition aimed at involving young artists in promoting the Sustainable Development Goals (SDGs) through visual arts. It is a joint initiative of the Embassy of Switzerland and the United Nations Information Centre (UNIC). First launched in 2016, We the Peoples, We the Arts involved students of leading art schools across Pakistan, who produced sculptures, paintings and miniature paintings, highlighting the theme of Zero Hunger, the second of 17 SDGs. Twenty-three finalists participated in the award ceremony held in Islamabad in November 2016. Three winners were selected by international contemporary experts including Alexie Glass-Cantor, Executive Director of Artspace Sydney and Curator of Encounters Art Basel Hong Kong; Priyanka Mathew, Principal Partner at Sunderlande New York; Karin Seiz, Co-Director of Galerie Urs Meile in Beijing and Lucerne; and Heike Munder, Director of Migros Museum for Contemporary Art in Zurich. The jury included also representatives from the Swiss Embassy and the United Nations. Artworks from all the 23 finalists were featured in a high-end catalogue and have been exhibited throughout Pakistan. To build on the success of this initiative, partners have decided to launch a second edition and expand participation and thematic areas of the competition."
                ),
                new Competition(
                02,
                "Art Competition",
                DateTime.ParseExact("2018-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2018-10-29", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster2.jpg",
                "1st prize: 500$; 2nd prize: 200$; 3rd prize: 100$",
                "DRAWING , ART, COLOURING,PAINTING CONTEST IN CHENNAI FOR VIJAYADASHAMI 2018"
                ),
                new Competition(
                03,
                "National Art Competition 2018",
                DateTime.ParseExact("2019-01-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2019-01-18", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster3.jpg",
                "1st prize: 1000$; 2nd prize: 500$; 3rd prize: 200$",
                "The exhibition will be based on the futuristic theme, India in the year 2040. You are encouraged to visualise a futuristic representation of our sentiments, hopes, culture, customs, cuisine, language, art, academics, society, values, or setting. India and her sky is the limit"
                ),
                new Competition(
                04,
                "15th Annual Art Competition",
                DateTime.ParseExact("2019-09-27", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2019-10-11", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster4.jpg",
                "1st prize: 500$; 2nd prize: 300$; 3rd prize: 200$",
                "Drawing, Digital Art, Mixed Media, Painting, Photography, Sculpture, Watercolor and Best in Show"
                ),
                new Competition(
                05,
                "National Art Competition",
                DateTime.ParseExact("2019-09-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2019-09-16", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster5.jpg",
                "1st prize: 15000$; 2nd prize: 10000$; 3rd prize: 5000$",
                "Let's make the amzing art"
                ),
                new Competition(
                06,
                "Student Art Exhibition & competition entry guide",
                DateTime.ParseExact("2017-04-11", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2017-04-12", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster6.jpg",
                "1st prize: 500$; 2nd prize: 300$; 3rd prize: 200$",
                "Found artist junior"
                ),
                new Competition(
                07,
                "On The Spot Painting Competition",
                DateTime.ParseExact("2019-02-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2019-02-16", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster7.jpg",
                "1st prize: 40k peso; 2nd prize: 30k peso; 3rd prize: 20k peso",
                "Viewing the shades of love"
                ),

                new Competition(
                08,
                "Love My Phone",
                DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2014-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster8.jpg",
                "1st prize: 2000$; 2nd prize: 1000$; 3rd prize: 500$",
                "Design your future , design your life"
                ),
                new Competition(
                09,
                "Live Painting",
                DateTime.ParseExact("2019-10-12", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2019-10-14", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster9.jpg",
                "1st prize: 1000$; 2nd prize: 750$; 3rd prize: 500$",
                "Make your soul pretty"
                ),
                new Competition(
                10,
                 "Pencil Park Drawing Competition",
                DateTime.ParseExact("2018-08-26", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                DateTime.ParseExact("2018-08-26", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                "~/Content/img/poster10.jpg",
                "1st prize: 50 inch sony television; 2nd prize: 1000$; 3rd prize: 200$",
                "Drawing, Digital Art, Mixed Media, Painting, Photography, Sculpture, Watercolor and Best in Show"
                ));
            context.Submissions.AddOrUpdate(
                new Submission(
                    01, 
                    02, 
                    "~/Content/img/submissions/https://tylerstudentlife.files.wordpress.com/2010/05/87cover.jpg?w=584", 
                    "something"),
                new Submission(
                    02, 
                    03, 
                    "https://my.academyart.edu/content/dam/students/samuel-kam-environment-design-maiden-of-growth.jpgiuq8lBUMpFyokc5MZCJwdH+Y+iVcjI6AW8oRz1y5IUP/2Q==",
                    "something"),
                new Submission(
                    03, 
                    04, 
                    "https://lh3.googleusercontent.com/proxy/J0wTUqvVhWH5KJ6gFL0QSv2DCeQx5gcDBFS7-7T9K2SdZ4EP2O8UQCZyRgqk89-LZWlistZM4HUC9y83TwhkixZkZD9hrqwmyyD-DyDFWWUfQ_Km3Jvr-_BqKiWhPvUV0csabe8Iu4yBknBr", 
                    "something"), 
                new Submission(
                    04, 
                    05, 
                    "https://s3.amazonaws.com/assets.saam.media/files/styles/x_large/s3/files/images/1963/SAAM-1963.9.14_1.jpg?itok=JeoQ7SdR", 
                    "something"), 
                new Submission(
                    05, 
                    06, 
                    "https://philhazard.files.wordpress.com/2012/08/7-student-painting-still-life-oil.jpg?w=848", 
                    "something"), 
                new Submission(
                    06, 
                    07, 
                    "https://i.pinimg.com/originals/06/36/24/063624c56d477288251b9a5ca2f7fdbe.jpg", 
                    "something"), 
                new Submission(
                    06, 
                    07, 
                    "https://college.lclark.edu/live/image/gid/210/width/300/height/600/26087_art_show.rev.1373935423.jpg", 
                    "something"), 
                new Submission(
                    07, 
                    08, 
                    "https://2qibqm39xjt6q46gf1rwo2g1-wpengine.netdna-ssl.com/wp-content/uploads/2019/02/15412689_web1_M1-Schack-Art-edh-190207.jpg", "something"), 
                new Submission(
                    08,
                    09, 
                    "https://www.artsmartmanila.com/uploads/8/8/3/9/8839968/30223755-1763693050362355-418249474-o_2_orig.jpg", "something"), 
                new Submission(
                    09, 
                    10, 
                    "https://i.etsystatic.com/5118220/r/il/5cb486/2085880972/il_570xN.2085880972_dicd.jpg", 
                    "something")
                );

        }
    }
}
