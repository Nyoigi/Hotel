using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hotel.Models
{
    public partial class MyHotelsContext : DbContext
    {
        public MyHotelsContext()
        {
        }

        public MyHotelsContext(DbContextOptions<MyHotelsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalService> AdditionalServices { get; set; }
        public virtual DbSet<BookingTime> BookingTimes { get; set; }
        public virtual DbSet<Cashbox> Cashboxes { get; set; }
        public virtual DbSet<CheckIn> CheckIns { get; set; }
        public virtual DbSet<FinancialDepartament> FinancialDepartaments { get; set; }
        public virtual DbSet<GuestDetail> GuestDetails { get; set; }
        public virtual DbSet<KindOfWork> KindOfWorks { get; set; }
        public virtual DbSet<Maid> Maids { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MiniBar> MiniBars { get; set; }
        public virtual DbSet<OrderiringMealInRoom> OrderiringMealInRooms { get; set; }
        public virtual DbSet<PersonalArea> PersonalAreas { get; set; }
        public virtual DbSet<PhotoRoom> PhotoRooms { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<RoomClass> RoomClasses { get; set; }
        public virtual DbSet<TypeOfService> TypeOfServices { get; set; }
        public virtual DbSet<TypeOfTransaction> TypeOfTransactions { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AdditionalService>(entity =>
            {
                entity.HasKey(e => e.IdAdditionalServices);

                entity.ToTable("Additional_Services");

                entity.Property(e => e.IdAdditionalServices).HasColumnName("ID_Additional_Services");

                entity.Property(e => e.CashboxId).HasColumnName("Cashbox_ID");

                entity.Property(e => e.ServiceId).HasColumnName("Service_ID");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Service_name");

                entity.Property(e => e.WarehouseId).HasColumnName("Warehouse_ID");

                entity.HasOne(d => d.Cashbox)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.CashboxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cash");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_of_service");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Warehouse");
            });

            modelBuilder.Entity<BookingTime>(entity =>
            {
                entity.HasKey(e => e.IdTime);

                entity.ToTable("Booking_time");

                entity.Property(e => e.IdTime).HasColumnName("ID_Time");

                entity.Property(e => e.CheckInDate)
                    .HasColumnType("date")
                    .HasColumnName("Check_in_date");

                entity.Property(e => e.CheckOutDate)
                    .HasColumnType("date")
                    .HasColumnName("Check_out_date");
            });

            modelBuilder.Entity<Cashbox>(entity =>
            {
                entity.HasKey(e => e.IdCashbox);

                entity.ToTable("Cashbox");

                entity.Property(e => e.IdCashbox).HasColumnName("ID_Cashbox");

                entity.Property(e => e.FinancialDepartamentId).HasColumnName("Financial_departament_ID");

                entity.HasOne(d => d.FinancialDepartament)
                    .WithMany(p => p.Cashboxes)
                    .HasForeignKey(d => d.FinancialDepartamentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Financial_departament");
            });

            modelBuilder.Entity<CheckIn>(entity =>
            {
                entity.HasKey(e => e.IdCheckIn);

                entity.ToTable("Check_in");

                entity.Property(e => e.IdCheckIn).HasColumnName("ID_Check_in");

                entity.Property(e => e.AdditionalServicesId).HasColumnName("Additional_Services_ID");

                entity.HasOne(d => d.AdditionalServices)
                    .WithMany(p => p.CheckIns)
                    .HasForeignKey(d => d.AdditionalServicesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Additional_Services");
            });

            modelBuilder.Entity<FinancialDepartament>(entity =>
            {
                entity.HasKey(e => e.IdFinancialDepartament);

                entity.ToTable("Financial_departament");

                entity.Property(e => e.IdFinancialDepartament).HasColumnName("ID_Financial_departament");

                entity.Property(e => e.TypeOfTransactionId).HasColumnName("Type_of_transaction_ID");

                entity.HasOne(d => d.TypeOfTransaction)
                    .WithMany(p => p.FinancialDepartaments)
                    .HasForeignKey(d => d.TypeOfTransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_of_transaction");
            });

            modelBuilder.Entity<GuestDetail>(entity =>
            {
                entity.HasKey(e => e.IdGuestDetails);

                entity.ToTable("Guest_details");

                entity.Property(e => e.IdGuestDetails).HasColumnName("ID_Guest_details");

                entity.Property(e => e.CheckInId).HasColumnName("Check_in_ID");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PassportNumber).HasColumnName("Passport_number");

                entity.Property(e => e.PassportSeries).HasColumnName("Passport_series");

                entity.Property(e => e.ReservationId).HasColumnName("Reservation_ID");

                entity.Property(e => e.RoomClassId).HasColumnName("Room_class_ID");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimeId).HasColumnName("Time_ID");

                entity.HasOne(d => d.CheckIn)
                    .WithMany(p => p.GuestDetails)
                    .HasForeignKey(d => d.CheckInId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Check_in");

                entity.HasOne(d => d.Reservation)
                    .WithMany(p => p.GuestDetails)
                    .HasForeignKey(d => d.ReservationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.GuestDetails)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomHotel");
            });

            modelBuilder.Entity<KindOfWork>(entity =>
            {
                entity.HasKey(e => e.IdKindOfWork);

                entity.ToTable("Kind_of_work");

                entity.Property(e => e.IdKindOfWork).HasColumnName("ID_Kind_of_work");

                entity.Property(e => e.CleaningType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cleaning_type");
            });

            modelBuilder.Entity<Maid>(entity =>
            {
                entity.HasKey(e => e.IdMaids);

                entity.Property(e => e.IdMaids).HasColumnName("ID_Maids");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");

                entity.Property(e => e.NameOfTheDish)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Name_of_the_dish");
            });

            modelBuilder.Entity<MiniBar>(entity =>
            {
                entity.HasKey(e => e.IdMiniBar);

                entity.ToTable("Mini_bar");

                entity.Property(e => e.IdMiniBar).HasColumnName("ID_Mini_bar");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderiringMealInRoom>(entity =>
            {
                entity.HasKey(e => e.IdOrderiringMealInRoom);

                entity.ToTable("Orderiring_meal_in_room");

                entity.Property(e => e.IdOrderiringMealInRoom).HasColumnName("ID_Orderiring_meal_in_room");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("date")
                    .HasColumnName("Date_order");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.TimeOrder).HasColumnName("Time_order");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.OrderiringMealInRooms)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.OrderiringMealInRooms)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoomHot");
            });

            modelBuilder.Entity<PersonalArea>(entity =>
            {
                entity.HasKey(e => e.IdPersonal);

                entity.ToTable("Personal_area");

                entity.Property(e => e.IdPersonal).HasColumnName("ID_Personal");

                entity.Property(e => e.GuestDetailsId).HasColumnName("Guest_details_ID");

                entity.HasOne(d => d.GuestDetails)
                    .WithMany(p => p.PersonalAreas)
                    .HasForeignKey(d => d.GuestDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Guest_details");
            });

            modelBuilder.Entity<PhotoRoom>(entity =>
            {
                entity.HasKey(e => e.IdPhotoRoom);

                entity.ToTable("Photo_room");

                entity.Property(e => e.IdPhotoRoom).HasColumnName("ID_Photo_room");

                entity.Property(e => e.PhotoOfTheRoom)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Photo_of_the_room");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.IdReservation);

                entity.ToTable("Reservation");

                entity.Property(e => e.IdReservation).HasColumnName("ID_Reservation");

                entity.Property(e => e.CashboxId).HasColumnName("Cashbox_ID");

                entity.Property(e => e.RoomId).HasColumnName("Room_ID");

                entity.Property(e => e.TimeId).HasColumnName("Time_ID");

                entity.HasOne(d => d.Cashbox)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CashboxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cashbox");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_time");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant);

                entity.ToTable("Restaurant");

                entity.Property(e => e.IdRestaurant).HasColumnName("ID_Restaurant");

                entity.Property(e => e.CashboxId).HasColumnName("Cashbox_ID");

                entity.Property(e => e.MenuId).HasColumnName("Menu_ID");

                entity.Property(e => e.NumberOrder).HasColumnName("Number_order");

                entity.HasOne(d => d.Cashbox)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CashboxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CashboxHotel");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuHotel");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom);

                entity.ToTable("Room");

                entity.Property(e => e.IdRoom).HasColumnName("ID_Room");

                entity.Property(e => e.NameRoom)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Name_room");

                entity.Property(e => e.NumberOfRooms).HasColumnName("Number_of_rooms");

                entity.Property(e => e.NumberOfSeats).HasColumnName("Number_of_seats");

                entity.Property(e => e.PhotoRoomId).HasColumnName("Photo_room_ID");

                entity.Property(e => e.RoomClassId).HasColumnName("Room_class_ID");

                entity.Property(e => e.TimeId).HasColumnName("Time_ID");

                entity.HasOne(d => d.PhotoRoom)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.PhotoRoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Photo_room");

                entity.HasOne(d => d.RoomClass)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_Class");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Time");
            });

            modelBuilder.Entity<RoomClass>(entity =>
            {
                entity.HasKey(e => e.IdRoomClass);

                entity.ToTable("Room_class");

                entity.Property(e => e.IdRoomClass).HasColumnName("ID_Room_class");

                entity.Property(e => e.RoomType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Room_type");
            });

            modelBuilder.Entity<TypeOfService>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.ToTable("Type_of_service");

                entity.Property(e => e.IdService).HasColumnName("ID_Service");

                entity.Property(e => e.ServiceType)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Service_type");
            });

            modelBuilder.Entity<TypeOfTransaction>(entity =>
            {
                entity.HasKey(e => e.IdTypeOfTransaction);

                entity.ToTable("Type_of_transaction");

                entity.Property(e => e.IdTypeOfTransaction).HasColumnName("ID_Type_of_transaction");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.OperationName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Operation_name");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.IdWarehouse);

                entity.ToTable("Warehouse");

                entity.Property(e => e.IdWarehouse).HasColumnName("ID_Warehouse");

                entity.Property(e => e.MiniBarId).HasColumnName("Mini_bar_ID");

                entity.HasOne(d => d.MiniBar)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.MiniBarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mini_bar");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
