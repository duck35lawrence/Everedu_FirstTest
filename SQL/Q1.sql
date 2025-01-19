CREATE TABLE Weather 
(
	id int,
	recordDate Date UNIQUE,
	temperature int,
	PRIMARY KEY (id)
);

INSERT INTO Weather
	VALUES (1, '2015-01-01', 10),
		   (2, '2015-01-02', 25),
	       (3, '2015-01-03', 20),
	       (4, '2015-01-04', 30);

SELECT W1.id
FROM Weather W1
WHERE W1.temperature > (SELECT W2.temperature FROM Weather W2
					WHERE W2.recordDate = DATEADD(DAY, -1, W1.recordDate))