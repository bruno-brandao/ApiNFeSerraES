DELETE FROM Responses
GO

DELETE FROM Options	
GO

DELETE FROM Questions
GO

SET IDENTITY_INSERT Questions ON
GO

DBCC CHECKIDENT('[Questions]', RESEED)
GO	

INSERT INTO Questions
(
    QuestionId,
	[Order],
    Question,
    Active,
    DateInsert,
    DateUpdate
)
VALUES
	(1,1,'Em qual desses munic�pios a sua empresa est� estabelecida?',1,GETDATE(),GETDATE()),
	(2,2,'Quanto tempo de mercado tem a sua empresa?',1,GETDATE(),GETDATE()),
	(3,3,'Qual �rea de atua��o de sua empresa?',1,GETDATE(),GETDATE()),
	(4,4,'Qual o principal ramo do mercado sua empresa atende?',1,GETDATE(),GETDATE()),
	(5,5,'A quanto tempo voc� (usu�rio) trabalha com emiss�o de notas fiscais de servi�o?',1,GETDATE(),GETDATE()),
	(6,6,'Qual dispositivo abaixo voc� mais usa no seu dia-a-dia?',1,GETDATE(),GETDATE()),
	(7,7,'Qual dispositivo voc� gostaria de usar mais no seu dia-a-dia?',1,GETDATE(),GETDATE()),
	(8,8,'Voc� acredita que uma interface organizada faz diferen�a na facilidade de uso de um aplicativo?',1,GETDATE(),GETDATE()),
	(9,9,'Voc� prefere aplicativos que tenham uma interface mais amig�vel e bem organizada e que funcione bem ou que apenas um aplicativo que cumpra o que prometeu sem erros?',1,GETDATE(),GETDATE()),
	(10,10,'Tendo como base a experi�ncia de uso que voc� teve, como voc� avalia o NFSe F�cil?',1,GETDATE(),GETDATE()),
	(11,11,'Tendo como base que voc� j� fez uso de um ou mais portais para emiss�o de notas fiscais de servi�o de prefeituras como por exemplo de Serra - ES, como voc� avalia a experi�ncia de uso desses sistemas em geral?',1,GETDATE(),GETDATE()),
	(12,12,'De modo geral como voc� avalia a interface do NFSe F�cil?',1,GETDATE(),GETDATE()),
	(13,13,'Como voc� avalia a interface dos portais de emiss�o de notas fiscais que voc� j� utilizou?',1,GETDATE(),GETDATE()),
	(14,14,'Como voc� avalia as fun��es do NFSe F�cil?',1,GETDATE(),GETDATE()),
	(15,15,'Como voc� avalia as fun��es dos portais de emiss�o de nota fiscal que voc� j� utilizou?',1,GETDATE(),GETDATE()),
	(16,16,'Tendo em vista a utiliza��o do NFSe F�cil e a experi�ncia que voc� j� teve com portais de emiss�o de nota fiscal de servi�o de prefeituras, qual a seria probabilidade de voc� passar a usar somente o nosso aplicativo?',1,GETDATE(),GETDATE()),
	(17,17,'Comparando os dois sistemas, na sua opini�o qual atende melhor ao objetivo de emitir notas fiscais de servi�o?',1,GETDATE(),GETDATE()),
	(18,18,'O que voc� achou mais f�cil no NFSe F�cil?',1,GETDATE(),GETDATE()),
	(19,19,'Qual foi a sua maior dificuldade com o NFSe F�cil?',1,GETDATE(),GETDATE()),	
	(20,20,'Voc� indicaria NFSe F�cil como alternativa aos portais de emiss�o de NFSe para outras empresas?',1,GETDATE(),GETDATE())		
GO

DBCC CHECKIDENT('[Questions]', RESEED)
GO

SET IDENTITY_INSERT Questions OFF
GO


SET IDENTITY_INSERT Options ON
GO

DBCC CHECKIDENT('[Options]', RESEED)
GO	

INSERT INTO	Options
(
    OptionId,
    QuestionId,
    [Order],
    [Option],
    Correct,
    Active,
    DateInsert,
    DateUpdate
)
VALUES
	--Quest�o 01
	(1,1,1,'Serra',1,1,Getdate(),Getdate()),
	(2,1,2,'Vit�ria',1,1,Getdate(),Getdate()),
	(3,1,3,'Vila Velha',1,1,Getdate(),Getdate()),
	(4,1,4,'Cariacia',1,1,Getdate(),Getdate()),
	(5,1,5,'Viana',1,1,Getdate(),Getdate()),	
	(6,1,6,'Fund�o',1,1,Getdate(),Getdate()),
	(7,1,7,'Guarapari',1,1,Getdate(),Getdate()),
	(8,1,8,'Outros',1,1,Getdate(),Getdate()),
	--Quest�o 02
	(9,2,1,'De 0 a 2 anos',1,1,Getdate(),Getdate()),
	(10,2,2,'De 3 a 5 anos',1,1,Getdate(),Getdate()),
	(11,2,3,'De 6 a 8 anos',1,1,Getdate(),Getdate()),
	(12,2,4,'De 9 a 10 anos',1,1,Getdate(),Getdate()),
	(13,2,5,'Mais de 10 anos',1,1,Getdate(),Getdate()),
	--Quest�o 03
	(14,3,1,'Tecnologia',1,1,Getdate(),Getdate()),
	(15,3,2,'Finan�as',1,1,Getdate(),Getdate()),
	(16,3,3,'Vendas',1,1,Getdate(),Getdate()),
	(17,3,4,'Gest�o',1,1,Getdate(),Getdate()),
	(18,3,5,'Log�stica',1,1,Getdate(),Getdate()),
	(19,3,6,'Transporte',1,1,Getdate(),Getdate()),
	(20,3,7,'Direito',1,1,Getdate(),Getdate()),
	(21,3,8,'Medicina',1,1,Getdate(),Getdate()),
	(22,3,9,'Outros',1,1,Getdate(),Getdate()),
	--Quest�o 04
	(23,4,1,'Ind�stria',1,1,Getdate(),Getdate()),
	(24,4,2,'Distribui��o',1,1,Getdate(),Getdate()),
	(25,4,3,'Com�rcio',1,1,Getdate(),Getdate()),
	(26,4,4,'Servi�os',1,1,Getdate(),Getdate()),
	(27,4,5,'Todas as op��es anteriores',1,1,Getdate(),Getdate()),
	--Quest�o 05
	(28,5,1,'De 0 a 2 anos',1,1,Getdate(),Getdate()),
	(29,5,2,'De 3 a 5 anos',1,1,Getdate(),Getdate()),
	(30,5,3,'De 6 a 8 anos',1,1,Getdate(),Getdate()),
	(31,5,4,'De 9 a 10 anos',1,1,Getdate(),Getdate()),
	(32,5,5,'Mais de 10 anos',1,1,Getdate(),Getdate()),
	--Quest�o 06
	(33,6,1,'Computador de mesa',1,1,Getdate(),Getdate()),
	(34,6,2,'Notebook',1,1,Getdate(),Getdate()),
	(35,6,3,'Tablet',1,1,Getdate(),Getdate()),
	(36,6,4,'Celular',1,1,Getdate(),Getdate()),
	(37,6,5,'Nenhuma das op��es anteriores',1,1,Getdate(),Getdate()),
	--Quest�o 07
	(38,7,1,'Computador de mesa',1,1,Getdate(),Getdate()),
	(39,7,2,'Notebook',1,1,Getdate(),Getdate()),
	(40,7,3,'Tablet',1,1,Getdate(),Getdate()),
	(41,7,4,'Celular',1,1,Getdate(),Getdate()),
	(42,7,5,'Nenhuma das op��es anteriores',1,1,Getdate(),Getdate()),
	--Quest�o 08
	(43,8,1,'Sim. Ajuda muito na ultiliza��o',1,1,Getdate(),Getdate()),
	(44,8,2,'N�o. � irrelevante',1,1,Getdate(),Getdate()),
	--Quest�o 09
	(45,9,1,'Interfaces mais amig�veis e bom funcionamento',1,1,Getdate(),Getdate()),
	(46,9,2,'Cumpre o que promete e nada mais',1,1,Getdate(),Getdate()),
	--Quest�o 10
	(47,10,1,'�timo. Simples e f�cil de usar n�o apresenta problemas',1,1,Getdate(),Getdate()),
	(48,10,2,'Bom. Atende bem as necessidades',1,1,Getdate(),Getdate()),
	(49,10,3,'Razo�vel. Atende as necessidades, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(50,10,4,'Ruim.  � de dif�cil utiliza��o e apresenta alguns problemas',1,1,Getdate(),Getdate()),
	(51,10,5,'P�ssimo.  Muito dif�cil de utilizar a interface quase n�o ajuda e apresenta problemas diversos',1,1,Getdate(),Getdate()),
	--Quest�o 11
	(52,11,1,'�timo. S�o simples e f�ceis de usar n�o apresenta problemas',1,1,Getdate(),Getdate()),
	(53,11,2,'Bom. Atendem bem �s necessidades',1,1,Getdate(),Getdate()),
	(54,11,3,'Razo�vel. Atende as necessidades, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(55,11,4,'Ruim.  � de dif�cil utiliza��o e apresenta alguns problemas',1,1,Getdate(),Getdate()),
	(56,11,5,'P�ssimo.  Muito dif�cil de utilizar a interface quase n�o ajuda e apresenta problemas diversos',1,1,Getdate(),Getdate()),
	--Quest�o 12
	(57,12,1,'�tima. Muito f�cil navegar e entender as fun��es',1,1,Getdate(),Getdate()),
	(58,12,2,'Bom. Consigo fazer as fun��es sem problemas',1,1,Getdate(),Getdate()),
	(59,12,3,'Razo�vel. Consigo fazer as fun��es b�sicas, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(60,12,4,'Ruim. Fiquei perdido tentando entender as fun��es',1,1,Getdate(),Getdate()),
	(61,12,5,'P�ssimo. N�o consegui utilizar a aplica��o',1,1,Getdate(),Getdate()),
	--Quest�o 13
	(62,13,1,'�tima. Muito f�cil navegar e entender as fun��es',1,1,Getdate(),Getdate()),
	(63,13,2,'Bom. Consigo fazer as fun��es sem problemas',1,1,Getdate(),Getdate()),
	(64,13,3,'Razo�vel. Consigo fazer as fun��es b�sicas, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(65,13,4,'Ruim. Fiquei perdido tentando entender as fun��es',1,1,Getdate(),Getdate()),
	(66,13,5,'P�ssimo. N�o consegui utilizar a aplica��o',1,1,Getdate(),Getdate()),
	--Quest�o 14
	(67,14,1,'�tima. Consigo fazer tudo que � necess�rio para emitir uma nota fiscal sem problemas',1,1,Getdate(),Getdate()),
	(68,14,2,'Razo�vel. Consigo emitir nota fiscal, mas faltam fun��es ou apresentam erros',1,1,Getdate(),Getdate()),
	(69,14,3,'P�ssimo. N�o consigo emitir nota fiscal por conta de erros e informa��es mal organizadas',1,1,Getdate(),Getdate()),
	--Quest�o 15
	(70,15,1,'�tima. Consigo fazer tudo para emitir uma nota fiscal sem problemas',1,1,Getdate(),Getdate()),
	(71,15,2,'Razo�vel. Consigo emitir nota fiscal, mas faltam fun��es ou apresentam erros',1,1,Getdate(),Getdate()),
	(72,15,3,'P�ssimo. N�o consigo emitir nota fiscal por conta de erros e informa��es mal organizadas',1,1,Getdate(),Getdate()),
	--Quest�o 16
	(73,16,1,'Grande. O aplicativo � muito intuitivo e f�cil de usar',1,1,Getdate(),Getdate()),
	(74,16,2,'Talvez. N�o vejo muita mudan�a',1,1,Getdate(),Getdate()),
	(75,16,3,'Nenhuma. O aplicativo n�o atendeu as minhas expectativas',1,1,Getdate(),Getdate()),
	(76,16,4,'Usaria ambos',1,1,Getdate(),Getdate()),
	--Quest�o 17
	(77,17,1,'O nosso aplicativo',1,1,Getdate(),Getdate()),
	(78,17,2,'Os portais das prefeituras municipais',1,1,Getdate(),Getdate()),
	(79,17,3,'Ambos se equiparam',1,1,Getdate(),Getdate()),
	(80,17,4,'Um � complementar ao outro',1,1,Getdate(),Getdate()),
	--Quest�o 18
	(86,18,1,'Interface gr�fica organizada e padronizada',1,1,Getdate(),Getdate()),
	(87,18,2,'Fun��es e/ou recursos bem definidos',1,1,Getdate(),Getdate()),
	(88,18,3,'Poucos ou nenhum erro',1,1,Getdate(),Getdate()),
	(89,18,4,'F�cil assimila��o de navega��o e acesso �s fun��es',1,1,Getdate(),Getdate()),
	(90,18,5,'N�o achei nada f�cil',1,1,Getdate(),Getdate()),	
	--Quest�o 19
	(81,19,1,'Interface gr�fica desorganizada ou fora de padr�o',1,1,Getdate(),Getdate()),
	(82,19,2,'Falta de fun��es e/ou recursos',1,1,Getdate(),Getdate()),
	(83,19,3,'Erros diversos',1,1,Getdate(),Getdate()),
	(84,19,4,'Dificuldade de navega��o e acesso �s fun��es',1,1,Getdate(),Getdate()),
	(85,19,5,'N�o tive dificuldades',1,1,Getdate(),Getdate()),
	--Quest�o 20
	(91,20,1,'Com certeza. O aplicativo � muito �til',1,1,Getdate(),Getdate()),
	(92,20,2,'Sim',1,1,Getdate(),Getdate()),
	(93,20,3,'Talvez. Depende da necessidade',1,1,Getdate(),Getdate()),
	(94,20,4,'N�o',1,1,Getdate(),Getdate()),
	(95,20,5,'Jamais. O aplicativo n�o � relevante para outras empresas',1,1,Getdate(),Getdate())
GO

DBCC CHECKIDENT('[Options]', RESEED)
GO

SET IDENTITY_INSERT Options OFF
GO

Select * From questions
Select * From options
Select * From responses