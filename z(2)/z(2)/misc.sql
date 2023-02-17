create table Tovary
(
id_tovara int not null,
nazvanie_tovara varchar(50) not null,
id_kategorii int not null,
id_proizvoditelya int not null,
kolichestvo_na_sklade int not null,
primary key (id_tovara)
)

create table Kategorii
(
id_kategorii int not null,
nazvanie_kategorii varchar(50) not null,
primary key (id_kategorii)
)

create table Proizvoditeli
(
id_proizvoditelya int not null,
nazvanie_proizvoditelya varchar(50) not null,
strana_proizvoditelya varchar(50) not null,
primary key (id_proizvoditelya)
)

create table Pokupateli
(
id_pokupatelya int not null,
f_pokupatelya varchar(30) not null,
i_pokupatelya varchar(30) not null,
o_pokupatelya varchar(30) null,
gorod varchar(30) null,
telefon varchar(12) null,
primary key (id_pokupatelya) 
)

create table Zakazy
(
id_zakaza int not null,
id_pokupatelya int not null,
data_zakaza date not null,
oplachen bit not null,
primary key (id_zakaza, id_pokupatelya)
)

create table Soderzhimoe_zakaza
(
id_zakaza int not null,
id_pokupatelya int not null,
id_tovara int not null,
kolichestvo int not null,
primary key (id_zakaza, id_pokupatelya, id_tovara)
)

alter table Tovary add foreign key (id_kategorii) references Kategorii (id_kategorii)
alter table Tovary add foreign key (id_proizvoditelya) references Proizvoditeli (id_proizvoditelya)
alter table Zakazy add foreign key (id_pokupatelya) references Pokupateli (id_pokupatelya)
alter table Soderzhimoe_zakaza add foreign key (id_tovara) references Tovary (id_tovara)
alter table Soderzhimoe_zakaza add foreign key (id_zakaza, id_pokupatelya) references Zakazy (id_zakaza, id_pokupatelya)