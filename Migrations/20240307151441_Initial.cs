using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZooManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Classification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SpeciesId = table.Column<int>(type: "integer", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateOfAcquisition = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "Classification", "Name" },
                values: new object[,]
                {
                    { -11, 1, "species_11" },
                    { -10, 2, "species_10" },
                    { -9, 4, "species_9" },
                    { -8, 2, "species_8" },
                    { -7, 5, "species_7" },
                    { -6, 1, "species_6" },
                    { -5, 3, "species_5" },
                    { -4, 1, "species_4" },
                    { -3, 5, "species_3" },
                    { -2, 2, "species_2" },
                    { -1, 0, "lion" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "Id", "DateOfAcquisition", "DateOfBirth", "Name", "Sex", "SpeciesId" },
                values: new object[,]
                {
                    { -119, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8150), new DateTime(2016, 4, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8149), "animal_119", 0, -11 },
                    { -118, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8138), new DateTime(2022, 5, 29, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8137), "animal_118", 1, -11 },
                    { -117, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8126), new DateTime(2017, 11, 24, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8126), "animal_117", 1, -11 },
                    { -116, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8114), new DateTime(2020, 12, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8114), "animal_116", 0, -11 },
                    { -115, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8102), new DateTime(2019, 3, 15, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8101), "animal_115", 0, -11 },
                    { -114, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8090), new DateTime(2016, 9, 2, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8089), "animal_114", 0, -11 },
                    { -113, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8078), new DateTime(2022, 4, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8077), "animal_113", 1, -11 },
                    { -112, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8066), new DateTime(2018, 10, 4, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8066), "animal_112", 0, -11 },
                    { -111, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8054), new DateTime(2022, 11, 8, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8053), "animal_111", 1, -11 },
                    { -110, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8042), new DateTime(2019, 8, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8041), "animal_110", 1, -11 },
                    { -109, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8013), new DateTime(2017, 9, 10, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(8012), "animal_109", 0, -10 },
                    { -108, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7999), new DateTime(2021, 8, 17, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7999), "animal_108", 1, -10 },
                    { -107, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7951), new DateTime(2021, 8, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7950), "animal_107", 0, -10 },
                    { -106, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7940), new DateTime(2020, 6, 24, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7939), "animal_106", 0, -10 },
                    { -105, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7928), new DateTime(2020, 7, 17, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7928), "animal_105", 0, -10 },
                    { -104, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7917), new DateTime(2021, 1, 26, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7916), "animal_104", 0, -10 },
                    { -103, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7904), new DateTime(2021, 11, 15, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7903), "animal_103", 0, -10 },
                    { -102, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7891), new DateTime(2019, 7, 26, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7891), "animal_102", 1, -10 },
                    { -101, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7879), new DateTime(2016, 12, 31, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7878), "animal_101", 1, -10 },
                    { -100, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7867), new DateTime(2020, 5, 10, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7866), "animal_100", 0, -10 },
                    { -99, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7840), new DateTime(2019, 6, 5, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7840), "animal_99", 1, -9 },
                    { -98, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7829), new DateTime(2019, 8, 26, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7828), "animal_98", 0, -9 },
                    { -97, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7818), new DateTime(2020, 9, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7818), "animal_97", 0, -9 },
                    { -96, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7807), new DateTime(2024, 1, 19, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7806), "animal_96", 0, -9 },
                    { -95, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7794), new DateTime(2022, 11, 16, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7794), "animal_95", 0, -9 },
                    { -94, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7782), new DateTime(2021, 4, 4, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7782), "animal_94", 0, -9 },
                    { -93, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7771), new DateTime(2022, 1, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7770), "animal_93", 0, -9 },
                    { -92, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7757), new DateTime(2022, 12, 1, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7756), "animal_92", 1, -9 },
                    { -91, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7745), new DateTime(2017, 2, 5, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7744), "animal_91", 1, -9 },
                    { -90, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7733), new DateTime(2022, 4, 27, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7732), "animal_90", 1, -9 },
                    { -89, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7705), new DateTime(2020, 7, 27, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7705), "animal_89", 0, -8 },
                    { -88, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7693), new DateTime(2023, 9, 29, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7692), "animal_88", 1, -8 },
                    { -87, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7681), new DateTime(2019, 12, 9, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7680), "animal_87", 0, -8 },
                    { -86, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7668), new DateTime(2022, 8, 16, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7667), "animal_86", 1, -8 },
                    { -85, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7621), new DateTime(2022, 10, 9, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7620), "animal_85", 1, -8 },
                    { -84, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7608), new DateTime(2021, 6, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7608), "animal_84", 1, -8 },
                    { -83, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7597), new DateTime(2018, 5, 29, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7596), "animal_83", 0, -8 },
                    { -82, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7585), new DateTime(2021, 4, 28, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7584), "animal_82", 1, -8 },
                    { -81, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7572), new DateTime(2016, 4, 22, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7572), "animal_81", 1, -8 },
                    { -80, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7560), new DateTime(2018, 6, 10, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7559), "animal_80", 0, -8 },
                    { -79, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7535), new DateTime(2021, 1, 2, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7535), "animal_79", 0, -7 },
                    { -78, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7523), new DateTime(2021, 9, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7522), "animal_78", 1, -7 },
                    { -77, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7512), new DateTime(2022, 10, 19, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7511), "animal_77", 0, -7 },
                    { -76, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7501), new DateTime(2022, 10, 10, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7500), "animal_76", 1, -7 },
                    { -75, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7489), new DateTime(2023, 11, 4, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7488), "animal_75", 0, -7 },
                    { -74, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7477), new DateTime(2017, 1, 24, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7476), "animal_74", 0, -7 },
                    { -73, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7465), new DateTime(2016, 8, 23, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7465), "animal_73", 1, -7 },
                    { -72, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7453), new DateTime(2021, 9, 15, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7452), "animal_72", 0, -7 },
                    { -71, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7440), new DateTime(2017, 2, 11, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7440), "animal_71", 1, -7 },
                    { -70, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7429), new DateTime(2018, 7, 2, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7428), "animal_70", 0, -7 },
                    { -69, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7399), new DateTime(2020, 12, 28, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7399), "animal_69", 1, -6 },
                    { -68, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7387), new DateTime(2022, 6, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7386), "animal_68", 0, -6 },
                    { -67, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7373), new DateTime(2023, 10, 4, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7373), "animal_67", 1, -6 },
                    { -66, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7312), new DateTime(2017, 7, 3, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7312), "animal_66", 0, -6 },
                    { -65, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7300), new DateTime(2020, 3, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7300), "animal_65", 0, -6 },
                    { -64, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7288), new DateTime(2022, 9, 3, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7288), "animal_64", 0, -6 },
                    { -63, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7278), new DateTime(2019, 11, 17, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7277), "animal_63", 0, -6 },
                    { -62, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7266), new DateTime(2021, 8, 14, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7266), "animal_62", 0, -6 },
                    { -61, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7255), new DateTime(2016, 10, 15, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7254), "animal_61", 1, -6 },
                    { -60, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7241), new DateTime(2017, 7, 23, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7240), "animal_60", 0, -6 },
                    { -59, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7216), new DateTime(2017, 1, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7216), "animal_59", 0, -5 },
                    { -58, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7204), new DateTime(2018, 5, 2, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7204), "animal_58", 0, -5 },
                    { -57, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7191), new DateTime(2021, 11, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7191), "animal_57", 1, -5 },
                    { -56, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7179), new DateTime(2021, 7, 2, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7179), "animal_56", 0, -5 },
                    { -55, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7166), new DateTime(2019, 2, 4, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7166), "animal_55", 0, -5 },
                    { -54, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7155), new DateTime(2022, 5, 14, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7154), "animal_54", 1, -5 },
                    { -53, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7142), new DateTime(2021, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7142), "animal_53", 1, -5 },
                    { -52, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7130), new DateTime(2023, 11, 5, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7130), "animal_52", 0, -5 },
                    { -51, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7119), new DateTime(2021, 2, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7118), "animal_51", 0, -5 },
                    { -50, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7105), new DateTime(2019, 10, 15, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7104), "animal_50", 1, -5 },
                    { -49, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7078), new DateTime(2024, 2, 26, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7077), "animal_49", 0, -4 },
                    { -48, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7065), new DateTime(2023, 11, 6, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7064), "animal_48", 1, -4 },
                    { -47, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7052), new DateTime(2022, 7, 17, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(7051), "animal_47", 0, -4 },
                    { -46, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6976), new DateTime(2023, 12, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6975), "animal_46", 0, -4 },
                    { -45, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6964), new DateTime(2015, 12, 24, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6963), "animal_45", 1, -4 },
                    { -44, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6952), new DateTime(2023, 7, 13, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6951), "animal_44", 0, -4 },
                    { -43, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6941), new DateTime(2021, 8, 31, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6940), "animal_43", 1, -4 },
                    { -42, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6929), new DateTime(2020, 6, 14, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6928), "animal_42", 0, -4 },
                    { -41, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6915), new DateTime(2021, 10, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6915), "animal_41", 0, -4 },
                    { -40, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6903), new DateTime(2024, 1, 25, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6903), "animal_40", 1, -4 },
                    { -39, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6879), new DateTime(2021, 12, 30, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6878), "animal_39", 0, -3 },
                    { -38, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6867), new DateTime(2021, 4, 17, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6867), "animal_38", 1, -3 },
                    { -37, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6854), new DateTime(2023, 12, 3, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6854), "animal_37", 1, -3 },
                    { -36, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6843), new DateTime(2024, 1, 1, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6842), "animal_36", 0, -3 },
                    { -35, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6832), new DateTime(2017, 10, 23, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6831), "animal_35", 0, -3 },
                    { -34, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6819), new DateTime(2019, 6, 26, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6819), "animal_34", 0, -3 },
                    { -33, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6808), new DateTime(2023, 2, 25, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6807), "animal_33", 0, -3 },
                    { -32, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6794), new DateTime(2020, 7, 23, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6794), "animal_32", 0, -3 },
                    { -31, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6781), new DateTime(2019, 7, 21, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6780), "animal_31", 1, -3 },
                    { -30, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6768), new DateTime(2016, 2, 9, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6767), "animal_30", 0, -3 },
                    { -29, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6730), new DateTime(2018, 2, 16, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6730), "animal_29", 0, -2 },
                    { -28, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6717), new DateTime(2017, 11, 11, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6717), "animal_28", 1, -2 },
                    { -27, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6704), new DateTime(2019, 6, 12, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6703), "animal_27", 0, -2 },
                    { -26, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6688), new DateTime(2021, 9, 22, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6688), "animal_26", 1, -2 },
                    { -25, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6624), new DateTime(2022, 5, 1, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6623), "animal_25", 0, -2 },
                    { -24, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6612), new DateTime(2017, 9, 6, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6611), "animal_24", 1, -2 },
                    { -23, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6599), new DateTime(2020, 11, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6599), "animal_23", 1, -2 },
                    { -22, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6582), new DateTime(2019, 7, 23, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6581), "animal_22", 0, -2 },
                    { -21, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6568), new DateTime(2018, 6, 29, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6568), "animal_21", 0, -2 },
                    { -20, new DateTime(2024, 3, 7, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6550), new DateTime(2017, 1, 6, 15, 14, 41, 305, DateTimeKind.Utc).AddTicks(6540), "animal_20", 1, -2 },
                    { -2, new DateTime(2001, 2, 2, 18, 30, 0, 0, DateTimeKind.Utc), new DateTime(1997, 9, 9, 18, 30, 0, 0, DateTimeKind.Utc), "nala", 1, -1 },
                    { -1, new DateTime(1999, 12, 31, 18, 30, 0, 0, DateTimeKind.Utc), new DateTime(1997, 10, 15, 18, 30, 0, 0, DateTimeKind.Utc), "simba", 0, -1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SpeciesId",
                table: "Animals",
                column: "SpeciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Species");
        }
    }
}
