using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VLISSIDES.Migrations
{
    public partial class ImageExcel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "3c1ca803-5cef-4808-ba2e-08b8efc9c2ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "8752349b-72dd-4ac0-998c-c3f62a91cff0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "8ff18391-6526-4585-b426-197610a95c81");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff913b5c-9cb7-45eb-8a51-f23867da8ddc", "ba01cac6-9991-4933-b31e-ea674c382741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d81bebff-d7e8-4797-9e2c-81e2fd80a6f5", "2b2cd452-5680-417f-8368-8be5e5bae944" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "d610191a-172e-46f7-9c6a-82bf2e68bb5b", new DateTime(2023, 10, 15, 14, 3, 51, 764, DateTimeKind.Local).AddTicks(4968), "b393d520-5a3a-442e-9d5b-c24f473af263" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Petit Prince.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2681), "Le Petit Prince" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/La Nuit des temps.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2774), "La Nuit des temps" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Guépard.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2780), "Le Guépard" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Les Fourmis.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2784), "Les Fourmis" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Moby-Dick.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2788), "Moby-Dick" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Crime et Châtiment.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2792), "Crime et Châtiment" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Maître et Marguerite.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2796), "Le Maître et Marguerite" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Parfum.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2801), "Le Parfum" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Lion.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2805), "Le Lion" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/L'Étranger.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2810), "L'Étranger" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Chardonneret.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2819), "Le Chardonneret" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Harry Potter à l'école des sorciers.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2737), "Harry Potter à l'école des sorciers" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Journal d'Anne Frank.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2823), "Le Journal d'Anne Frank" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/La Ferme des Animaux.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2828), "La Ferme des Animaux" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/L'Odyssée.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2833), "L'Odyssée" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Vieil Homme et la Mer.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2837), "Le Vieil Homme et la Mer" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Journal de Bridget Jones.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2842), "Le Journal de Bridget Jones" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Meilleur des Mondes.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2846), "Le Meilleur des Mondes" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/L'Alchimiste.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2851), "L'Alchimiste" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Portrait de Dorian Gray.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2857), "Le Portrait de Dorian Gray" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Comte de Monte-Cristo.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2862), "Le Comte de Monte-Cristo" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Hobbit.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2866), "Le Hobbit" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/1984.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2744), "1984" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Les Trois Mousquetaires.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2871), "Les Trois Mousquetaires" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Les Cerfs-volants de Kaboul.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2876), "Les Cerfs-volants de Kaboul" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Grand Meaulnes.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2881), "Le Grand Meaulnes" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Journal de Kurt Cobain.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2885), "Le Journal de Kurt Cobain" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Les Fleurs du Mal.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2895), "Les Fleurs du Mal" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Parti pris des choses.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2902), "Le Parti pris des choses" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "/img/Couvertures/Les Contes de Grimm.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2907) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "/img/Couvertures/Contes de Perrault.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2913) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "/img/Couvertures/Les Contes d'Andersen.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2918) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "/img/Couvertures/Contes des Mille et Une Nuits.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Seigneur des Anneaux : La Communauté de l'Anneau.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2748), "Le Seigneur des Anneaux : La Communauté de l'Anneau" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "/img/Couvertures/Contes de la Rue Broca.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2928) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Pédagogie positive.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2934), "Pédagogie positive" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/L'École du Colibri.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2939), "L'École du Colibri" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Apprendre autrement avec la pédagogie positive.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2945), "Apprendre autrement avec la pédagogie positive" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le guide de survie enseignant suppléant.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2950), "Le guide de survie enseignant suppléant" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/La pédagogie Montessori à la maison.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2956), "La pédagogie Montessori à la maison" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Astérix le Gaulois.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2961), "Astérix le Gaulois" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Tintin au Tibet.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2967), "Tintin au Tibet" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Nom de la Rose.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2752), "Le Nom de la Rose" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Maus.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2972), "Maus" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Persepolis.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2978), "Persepolis" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Watchmen.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2983), "Watchmen" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Orgueil et Préjugés.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2757), "Orgueil et Préjugés" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/L'Écume des Jours.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2761), "L'Écume des Jours" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Les Misérables.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2765), "Les Misérables" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "/img/Couvertures/Le Rouge et le Noir.png", new DateTime(2023, 10, 15, 14, 3, 51, 757, DateTimeKind.Local).AddTicks(2769), "Le Rouge et le Noir" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "a2e02ed0-0b7f-4a79-8dcf-05feca2a5ff2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2f7b11d6-505c-47a6-898c-d622e13e5bed");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "239f406c-2269-469d-83d1-bfd8df65c42f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "639651b6-c480-45e4-8938-5df5ace92458", "7b8c8fb8-42c4-4bfb-8a42-d3ede70aa79b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0cb94885-3b70-4f7a-ac47-5a7ba62ed48f", "39ee626b-5d64-4693-a941-4bfd19f12bea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateAdhesion", "SecurityStamp" },
                values: new object[] { "75b82484-c39a-4df2-adf0-a9f254d10035", new DateTime(2023, 10, 5, 11, 16, 18, 416, DateTimeKind.Local).AddTicks(8820), "204ba0e9-3d65-4f17-bfaf-4f17ce152e96" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 1",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4150), "\"Le Petit Prince\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 10",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4230), "\"La Nuit des temps\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 11",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4230), "\"Le Guépard\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 12",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), "\"Les Fourmis\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 13",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), "\"Moby-Dick\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 14",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4240), "\"Crime et Châtiment\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 15",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), "\"Le Maître et Marguerite\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 16",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), "\"Le Parfum\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 17",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), "\"Le Lion\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 18",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4250), "\"L'Étranger\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 19",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), "\"Le Chardonneret\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 2",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4200), "\"Harry Potter à l'école des sorciers\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 20",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), "\"Le Journal d'Anne Frank\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 21",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4260), "\"La Ferme des Animaux\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 22",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), "\"L'Odyssée\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 23",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), "\"Le Vieil Homme et la Mer\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 24",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4270), "\"Le Journal de Bridget Jones\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 25",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), "\"Le Meilleur des Mondes\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 26",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), "\"L'Alchimiste\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 27",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4280), "\"Le Portrait de Dorian Gray\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 28",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), "\"Le Comte de Monte-Cristo\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 29",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), "\"Le Hobbit\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 3",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), "\"1984\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 30",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4290), "\"Les Trois Mousquetaires\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 31",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), "\"Les Cerfs-volants de Kaboul\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 32",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), "\"Le Grand Meaulnes\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 33",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4300), "\"Le Journal de Kurt Cobain\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 34",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310), "\"Les Fleurs du Mal\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 35",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310), "\"Le Parti pris des choses\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 36",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4310) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 37",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 38",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 39",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4320) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 4",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), "\"Le Seigneur des Anneaux : La Communauté de l'Anneau\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 40",
                columns: new[] { "Couverture", "DateAjout" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4330) });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 42",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4330), "\"Pédagogie positive\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 43",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), "\"L'École du Colibri\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 44",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), "\"Apprendre autrement avec la pédagogie positive\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 45",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4340), "\"Le guide de survie enseignant suppléant\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 46",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4350), "\"La pédagogie Montessori à la maison\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 48",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4350), "\"Astérix le Gaulois\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 49",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), "\"Tintin au Tibet\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 5",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4210), "\"Le Nom de la Rose\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 50",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), "\"Maus\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 51",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4360), "\"Persepolis\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 52",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4370), "\"Watchmen\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 6",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), "\"Orgueil et Préjugés\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 7",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), "\"L'Écume des Jours\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 8",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), "\"Les Misérables\"" });

            migrationBuilder.UpdateData(
                table: "Livres",
                keyColumn: "Id",
                keyValue: "Excel 9",
                columns: new[] { "Couverture", "DateAjout", "Titre" },
                values: new object[] { "", new DateTime(2023, 10, 5, 11, 16, 18, 414, DateTimeKind.Local).AddTicks(4220), "\"Le Rouge et le Noir\"" });
        }
    }
}
