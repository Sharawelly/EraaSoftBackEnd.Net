create database eraasoft
GO

USE eraasoft
GO

CREATE SCHEMA task1
GO

create table task1.actor (
	act_id integer primary key,
	act_fname varchar(20),
	act_lname varchar(20),
	act_gender varchar(1),
)

create table task1.director (
	dir_id integer primary key,
	dir_fname varchar(20),
	dir_lname varchar(20),
)

create table task1.movie_direction (
	dir_id integer,
	mov_id integer,
	PRIMARY KEY(dir_id, mov_id),
)


create table task1.movie_cast (
	act_id integer,
	mov_id integer,
	role varchar(30),
	PRIMARY KEY(act_id, mov_id),
	
)

create table task1.movie (
	mov_id integer primary key,
	mov_title varchar(50),
	mov_year integer,
	mov_time integer,
	mov_lang varchar(50),
	mov_dt_rel date,
	mov_rel_country varchar(5),
	
)

create table task1.reviewer (
	rev_id integer primary key,
	rev_name varchar(30),
)

create table task1.genres (
	gen_id integer primary key,
	gen_title varchar(30)
)

create table task1.movie_genres (
	mov_id integer,
	gen_id varchar(20),
	PRIMARY KEY(mov_id, gen_id),
)

create table task1.rating (
	mov_id integer,
	rev_id integer,
	rev_starts integer, 
	num_o_ratings integer,
	PRIMARY KEY(mov_id, rev_id),
)