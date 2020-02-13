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
            var list = new List<Competition>();

            list.Add(new Competition()
            {
                CompetitionId = 01,

            
            var list = new List<Competition>();

            list.Add(new Competition()
            {
                CompetitionId = 11,
                CompetitionName = "We are the peoples we the arts 2018",
                StartDate = DateTime.ParseExact("2017-12-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2018-06-18", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster1.jpg",
                AwardDetails = "1st prize: 1000$; 2nd prize: 500$; 3rd prize: 200$",
                Description = "We the Peoples,We the Arts is an art competition aimed at involving young artists in promoting the Sustainable Development Goals (SDGs) through visual arts. It is a joint initiative of the Embassy of Switzerland and the United Nations Information Centre (UNIC). First launched in 2016, We the Peoples, We the Arts involved students of leading art schools across Pakistan, who produced sculptures, paintings and miniature paintings, highlighting the theme of Zero Hunger, the second of 17 SDGs. Twenty-three finalists participated in the award ceremony held in Islamabad in November 2016. Three winners were selected by international contemporary experts including Alexie Glass-Cantor, Executive Director of Artspace Sydney and Curator of Encounters Art Basel Hong Kong; Priyanka Mathew, Principal Partner at Sunderlande New York; Karin Seiz, Co-Director of Galerie Urs Meile in Beijing and Lucerne; and Heike Munder, Director of Migros Museum for Contemporary Art in Zurich. The jury included also representatives from the Swiss Embassy and the United Nations. Artworks from all the 23 finalists were featured in a high-end catalogue and have been exhibited throughout Pakistan. To build on the success of this initiative, partners have decided to launch a second edition and expand participation and thematic areas of the competition."
            });
            list.Add(new Competition()
            {
                CompetitionId = 02,
                CompetitionName = "Art Competition",
                StartDate = DateTime.ParseExact("2018-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2018-10-29", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster2.jpg",
                AwardDetails = "1st prize: 500$; 2nd prize: 200$; 3rd prize: 100$",
                Description = "DRAWING , ART, COLOURING,PAINTING CONTEST IN CHENNAI FOR VIJAYADASHAMI 2018"
            });
            list.Add(new Competition()
            {
                CompetitionId = 03,
                CompetitionName = "National Art Competition 2018",
                StartDate = DateTime.ParseExact("2019-01-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2019-01-18", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster3.jpg",
                AwardDetails = "1st prize: 1000$; 2nd prize: 500$; 3rd prize: 200$",
                Description = "The exhibition will be based on the futuristic theme, India in the year 2040. You are encouraged to visualise a futuristic representation of our sentiments, hopes, culture, customs, cuisine, language, art, academics, society, values, or setting. India and her sky is the limit"

            });
            list.Add(new Competition()
            {
                CompetitionId = 04,
                CompetitionName = "15th Annual Art Competition",
                StartDate = DateTime.ParseExact("2019-09-27", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2019-10-11", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster4.jpg",
                AwardDetails = "1st prize: 500$; 2nd prize: 300$; 3rd prize: 200$",
                Description = "Drawing, Digital Art, Mixed Media, Painting, Photography, Sculpture, Watercolor and Best in Show"

            });
            list.Add(new Competition()
            {
                CompetitionId = 05,
                CompetitionName = "National Art Competition",
                StartDate = DateTime.ParseExact("2019-09-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2019-09-16", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster5.jpg",
                AwardDetails = "1st prize: 15000$; 2nd prize: 10000$; 3rd prize: 5000$",
                Description = "Let's make the amzing art"

            });
            list.Add(new Competition()
            {
                CompetitionId = 06,
                CompetitionName = "Student Art Exhibition & competition entry guide",
                StartDate = DateTime.ParseExact("2017-04-11", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2017-04-12", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster6.jpg",
                AwardDetails = "1st prize: 500$; 2nd prize: 300$; 3rd prize: 200$",
                Description = "Found artist junior"

            });
            list.Add(new Competition()
            {
                CompetitionId = 07,
                CompetitionName = "On The Spot Painting Competition",
                StartDate = DateTime.ParseExact("2019-02-15", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2019-02-16", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster7.jpg",
                AwardDetails = "1st prize: 40k peso; 2nd prize: 30k peso; 3rd prize: 20k peso",
                Description = "Viewing the shades of love"

            });
            list.Add(new Competition()
            {
                CompetitionId = 08,
                CompetitionName = "Love My Phone",
                StartDate = DateTime.ParseExact("2014-09-01", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2014-10-10", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster8.jpg",
                AwardDetails = "1st prize: 2000$; 2nd prize: 1000$; 3rd prize: 500$",
                Description = "Design your future , design your life"
            });
            list.Add(new Competition()
            {
                CompetitionId = 09,
                CompetitionName = "Live Painting",
                StartDate = DateTime.ParseExact("2019-10-12", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2019-10-14", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster9.jpg",
                AwardDetails = "1st prize: 1000$; 2nd prize: 750$; 3rd prize: 500$",
                Description = "Make your soul pretty"

            });
            list.Add(new Competition()
            {
                CompetitionId = 10,
                CompetitionName = "Pencil Park Drawing Competition",
                StartDate = DateTime.ParseExact("2018-08-26", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                EndDate = DateTime.ParseExact("2018-08-26", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                Image = "~/Content/img/poster10.jpg",
                AwardDetails = "1st prize: 50 inch sony television; 2nd prize: 1000$; 3rd prize: 200$",
                Description = "Drawing, Digital Art, Mixed Media, Painting, Photography, Sculpture, Watercolor and Best in Show"

            });

            context.Competitions.AddRange(list);
        }
    }
}
