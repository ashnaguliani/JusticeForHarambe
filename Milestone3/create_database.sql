Create database Leaderboard;
Use Leaderboard;
create table distance_board (username varchar(15) not null, Timestamp date not null, distance int not null, bananas int not null, score int not null);
create table banana_board (username varchar(15) not null, Timestamp date not null, bananas int not null, distance int not null, score int not null);
create table score_board (username varchar(15) not null, Timestamp date not null, score int not null, distance int not null, bananas int not null);
