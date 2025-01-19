CREATE TABLE Weather 
(
	id int,
	recordDate Date,
	temperature int,
	PRIMARY KEY (id)
);

INSERT INTO Weather
	VALUES (1, '2015-01-01', 10),
		   (2, '2015-01-02', 25),
	       (3, '2015-01-03', 20),
	       (4, '2015-01-04', 30);

SELECT * FROM Weather