using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBotQuestions_ChatBotQuestions_ChatBotQuestionId",
                table: "ChatBotQuestions");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "ScheduleTimeSlots");

            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InfoOpleiding",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InfoOver",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "InfoPublicaties",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Treatments",
                newName: "ImageLink");

            migrationBuilder.RenameColumn(
                name: "ChatBotQuestionId",
                table: "ChatBotQuestions",
                newName: "CMSChatBotQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatBotQuestions_ChatBotQuestionId",
                table: "ChatBotQuestions",
                newName: "IX_ChatBotQuestions_CMSChatBotQuestionId");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Blogs",
                newName: "ImageLink");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentType",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "TimeSlots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "TimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameDoctor",
                table: "TimeSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "ScheduleTimeSlots",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "ScheduleTimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameDoctor",
                table: "ScheduleTimeSlots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodType",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biograph",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageLink",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NameDoctor",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBotQuestions_ChatBotQuestions_CMSChatBotQuestionId",
                table: "ChatBotQuestions",
                column: "CMSChatBotQuestionId",
                principalTable: "ChatBotQuestions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBotQuestions_ChatBotQuestions_CMSChatBotQuestionId",
                table: "ChatBotQuestions");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "NameDoctor",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "ScheduleTimeSlots");

            migrationBuilder.DropColumn(
                name: "NameDoctor",
                table: "ScheduleTimeSlots");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Biograph",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "ImageLink",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "NameDoctor",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Treatments",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "CMSChatBotQuestionId",
                table: "ChatBotQuestions",
                newName: "ChatBotQuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatBotQuestions_CMSChatBotQuestionId",
                table: "ChatBotQuestions",
                newName: "IX_ChatBotQuestions_ChatBotQuestionId");

            migrationBuilder.RenameColumn(
                name: "ImageLink",
                table: "Blogs",
                newName: "Image");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentType",
                table: "TimeSlots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeSlots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "TimeSlots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "TimeSlots",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "ScheduleTimeSlots",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "ScheduleTimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Patients",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodGroup",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoOpleiding",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoOver",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoPublicaties",
                table: "Doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBotQuestions_ChatBotQuestions_ChatBotQuestionId",
                table: "ChatBotQuestions",
                column: "ChatBotQuestionId",
                principalTable: "ChatBotQuestions",
                principalColumn: "Id");
        }
    }
}
