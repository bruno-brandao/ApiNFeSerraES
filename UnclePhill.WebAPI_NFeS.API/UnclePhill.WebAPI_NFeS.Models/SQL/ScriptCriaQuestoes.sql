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
	(1,1,'Em qual desses municípios a sua empresa está estabelecida?',1,GETDATE(),GETDATE()),
	(2,2,'Quanto tempo de mercado tem a sua empresa?',1,GETDATE(),GETDATE()),
	(3,3,'Qual área de atuação de sua empresa?',1,GETDATE(),GETDATE()),
	(4,4,'Qual o principal ramo do mercado sua empresa atende?',1,GETDATE(),GETDATE()),
	(5,5,'A quanto tempo você (usuário) trabalha com emissão de notas fiscais de serviço?',1,GETDATE(),GETDATE()),
	(6,6,'Qual dispositivo abaixo você mais usa no seu dia-a-dia?',1,GETDATE(),GETDATE()),
	(7,7,'Qual dispositivo você gostaria de usar mais no seu dia-a-dia?',1,GETDATE(),GETDATE()),
	(8,8,'Você acredita que uma interface organizada faz diferença na facilidade de uso de um aplicativo?',1,GETDATE(),GETDATE()),
	(9,9,'Você prefere aplicativos que tenham uma interface mais amigável e bem organizada e que funcione bem ou que apenas um aplicativo que cumpra o que prometeu sem erros?',1,GETDATE(),GETDATE()),
	(10,10,'Tendo como base a experiência de uso que você teve, como você avalia o NFSe Fácil?',1,GETDATE(),GETDATE()),
	(11,11,'Tendo como base que você já fez uso de um ou mais portais para emissão de notas fiscais de serviço de prefeituras como por exemplo de Serra - ES, como você avalia a experiência de uso desses sistemas em geral?',1,GETDATE(),GETDATE()),
	(12,12,'De modo geral como você avalia a interface do NFSe Fácil?',1,GETDATE(),GETDATE()),
	(13,13,'Como você avalia a interface dos portais de emissão de notas fiscais que você já utilizou?',1,GETDATE(),GETDATE()),
	(14,14,'Como você avalia as funções do NFSe Fácil?',1,GETDATE(),GETDATE()),
	(15,15,'Como você avalia as funções dos portais de emissão de nota fiscal que você já utilizou?',1,GETDATE(),GETDATE()),
	(16,16,'Tendo em vista a utilização do NFSe Fácil e a experiência que você já teve com portais de emissão de nota fiscal de serviço de prefeituras, qual a seria probabilidade de você passar a usar somente o nosso aplicativo?',1,GETDATE(),GETDATE()),
	(17,17,'Comparando os dois sistemas, na sua opinião qual atende melhor ao objetivo de emitir notas fiscais de serviço?',1,GETDATE(),GETDATE()),
	(18,18,'O que você achou mais fácil no NFSe Fácil?',1,GETDATE(),GETDATE()),
	(19,19,'Qual foi a sua maior dificuldade com o NFSe Fácil?',1,GETDATE(),GETDATE()),	
	(20,20,'Você indicaria NFSe Fácil como alternativa aos portais de emissão de NFSe para outras empresas?',1,GETDATE(),GETDATE())		
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
	--Questão 01
	(1,1,1,'Serra',1,1,Getdate(),Getdate()),
	(2,1,2,'Vitória',1,1,Getdate(),Getdate()),
	(3,1,3,'Vila Velha',1,1,Getdate(),Getdate()),
	(4,1,4,'Cariacia',1,1,Getdate(),Getdate()),
	(5,1,5,'Viana',1,1,Getdate(),Getdate()),	
	(6,1,6,'Fundão',1,1,Getdate(),Getdate()),
	(7,1,7,'Guarapari',1,1,Getdate(),Getdate()),
	(8,1,8,'Outros',1,1,Getdate(),Getdate()),
	--Questão 02
	(9,2,1,'De 0 a 2 anos',1,1,Getdate(),Getdate()),
	(10,2,2,'De 3 a 5 anos',1,1,Getdate(),Getdate()),
	(11,2,3,'De 6 a 8 anos',1,1,Getdate(),Getdate()),
	(12,2,4,'De 9 a 10 anos',1,1,Getdate(),Getdate()),
	(13,2,5,'Mais de 10 anos',1,1,Getdate(),Getdate()),
	--Questão 03
	(14,3,1,'Tecnologia',1,1,Getdate(),Getdate()),
	(15,3,2,'Finanças',1,1,Getdate(),Getdate()),
	(16,3,3,'Vendas',1,1,Getdate(),Getdate()),
	(17,3,4,'Gestão',1,1,Getdate(),Getdate()),
	(18,3,5,'Logística',1,1,Getdate(),Getdate()),
	(19,3,6,'Transporte',1,1,Getdate(),Getdate()),
	(20,3,7,'Direito',1,1,Getdate(),Getdate()),
	(21,3,8,'Medicina',1,1,Getdate(),Getdate()),
	(22,3,9,'Outros',1,1,Getdate(),Getdate()),
	--Questão 04
	(23,4,1,'Indústria',1,1,Getdate(),Getdate()),
	(24,4,2,'Distribuição',1,1,Getdate(),Getdate()),
	(25,4,3,'Comércio',1,1,Getdate(),Getdate()),
	(26,4,4,'Serviços',1,1,Getdate(),Getdate()),
	(27,4,5,'Todas as opções anteriores',1,1,Getdate(),Getdate()),
	--Questão 05
	(28,5,1,'De 0 a 2 anos',1,1,Getdate(),Getdate()),
	(29,5,2,'De 3 a 5 anos',1,1,Getdate(),Getdate()),
	(30,5,3,'De 6 a 8 anos',1,1,Getdate(),Getdate()),
	(31,5,4,'De 9 a 10 anos',1,1,Getdate(),Getdate()),
	(32,5,5,'Mais de 10 anos',1,1,Getdate(),Getdate()),
	--Questão 06
	(33,6,1,'Computador de mesa',1,1,Getdate(),Getdate()),
	(34,6,2,'Notebook',1,1,Getdate(),Getdate()),
	(35,6,3,'Tablet',1,1,Getdate(),Getdate()),
	(36,6,4,'Celular',1,1,Getdate(),Getdate()),
	(37,6,5,'Nenhuma das opções anteriores',1,1,Getdate(),Getdate()),
	--Questão 07
	(38,7,1,'Computador de mesa',1,1,Getdate(),Getdate()),
	(39,7,2,'Notebook',1,1,Getdate(),Getdate()),
	(40,7,3,'Tablet',1,1,Getdate(),Getdate()),
	(41,7,4,'Celular',1,1,Getdate(),Getdate()),
	(42,7,5,'Nenhuma das opções anteriores',1,1,Getdate(),Getdate()),
	--Questão 08
	(43,8,1,'Sim. Ajuda muito na ultilização',1,1,Getdate(),Getdate()),
	(44,8,2,'Não. É irrelevante',1,1,Getdate(),Getdate()),
	--Questão 09
	(45,9,1,'Interfaces mais amigáveis e bom funcionamento',1,1,Getdate(),Getdate()),
	(46,9,2,'Cumpre o que promete e nada mais',1,1,Getdate(),Getdate()),
	--Questão 10
	(47,10,1,'Ótimo. Simples e fácil de usar não apresenta problemas',1,1,Getdate(),Getdate()),
	(48,10,2,'Bom. Atende bem as necessidades',1,1,Getdate(),Getdate()),
	(49,10,3,'Razoável. Atende as necessidades, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(50,10,4,'Ruim.  É de difícil utilização e apresenta alguns problemas',1,1,Getdate(),Getdate()),
	(51,10,5,'Péssimo.  Muito difícil de utilizar a interface quase não ajuda e apresenta problemas diversos',1,1,Getdate(),Getdate()),
	--Questão 11
	(52,11,1,'Ótimo. São simples e fáceis de usar não apresenta problemas',1,1,Getdate(),Getdate()),
	(53,11,2,'Bom. Atendem bem às necessidades',1,1,Getdate(),Getdate()),
	(54,11,3,'Razoável. Atende as necessidades, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(55,11,4,'Ruim.  É de difícil utilização e apresenta alguns problemas',1,1,Getdate(),Getdate()),
	(56,11,5,'Péssimo.  Muito difícil de utilizar a interface quase não ajuda e apresenta problemas diversos',1,1,Getdate(),Getdate()),
	--Questão 12
	(57,12,1,'Ótima. Muito fácil navegar e entender as funções',1,1,Getdate(),Getdate()),
	(58,12,2,'Bom. Consigo fazer as funções sem problemas',1,1,Getdate(),Getdate()),
	(59,12,3,'Razoável. Consigo fazer as funções básicas, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(60,12,4,'Ruim. Fiquei perdido tentando entender as funções',1,1,Getdate(),Getdate()),
	(61,12,5,'Péssimo. Não consegui utilizar a aplicação',1,1,Getdate(),Getdate()),
	--Questão 13
	(62,13,1,'Ótima. Muito fácil navegar e entender as funções',1,1,Getdate(),Getdate()),
	(63,13,2,'Bom. Consigo fazer as funções sem problemas',1,1,Getdate(),Getdate()),
	(64,13,3,'Razoável. Consigo fazer as funções básicas, mas poderia ser melhor',1,1,Getdate(),Getdate()),
	(65,13,4,'Ruim. Fiquei perdido tentando entender as funções',1,1,Getdate(),Getdate()),
	(66,13,5,'Péssimo. Não consegui utilizar a aplicação',1,1,Getdate(),Getdate()),
	--Questão 14
	(67,14,1,'Ótima. Consigo fazer tudo que é necessário para emitir uma nota fiscal sem problemas',1,1,Getdate(),Getdate()),
	(68,14,2,'Razoável. Consigo emitir nota fiscal, mas faltam funções ou apresentam erros',1,1,Getdate(),Getdate()),
	(69,14,3,'Péssimo. Não consigo emitir nota fiscal por conta de erros e informações mal organizadas',1,1,Getdate(),Getdate()),
	--Questão 15
	(70,15,1,'Ótima. Consigo fazer tudo para emitir uma nota fiscal sem problemas',1,1,Getdate(),Getdate()),
	(71,15,2,'Razoável. Consigo emitir nota fiscal, mas faltam funções ou apresentam erros',1,1,Getdate(),Getdate()),
	(72,15,3,'Péssimo. Não consigo emitir nota fiscal por conta de erros e informações mal organizadas',1,1,Getdate(),Getdate()),
	--Questão 16
	(73,16,1,'Grande. O aplicativo é muito intuitivo e fácil de usar',1,1,Getdate(),Getdate()),
	(74,16,2,'Talvez. Não vejo muita mudança',1,1,Getdate(),Getdate()),
	(75,16,3,'Nenhuma. O aplicativo não atendeu as minhas expectativas',1,1,Getdate(),Getdate()),
	(76,16,4,'Usaria ambos',1,1,Getdate(),Getdate()),
	--Questão 17
	(77,17,1,'O nosso aplicativo',1,1,Getdate(),Getdate()),
	(78,17,2,'Os portais das prefeituras municipais',1,1,Getdate(),Getdate()),
	(79,17,3,'Ambos se equiparam',1,1,Getdate(),Getdate()),
	(80,17,4,'Um é complementar ao outro',1,1,Getdate(),Getdate()),
	--Questão 18
	(86,18,1,'Interface gráfica organizada e padronizada',1,1,Getdate(),Getdate()),
	(87,18,2,'Funções e/ou recursos bem definidos',1,1,Getdate(),Getdate()),
	(88,18,3,'Poucos ou nenhum erro',1,1,Getdate(),Getdate()),
	(89,18,4,'Fácil assimilação de navegação e acesso às funções',1,1,Getdate(),Getdate()),
	(90,18,5,'Não achei nada fácil',1,1,Getdate(),Getdate()),	
	--Questão 19
	(81,19,1,'Interface gráfica desorganizada ou fora de padrão',1,1,Getdate(),Getdate()),
	(82,19,2,'Falta de funções e/ou recursos',1,1,Getdate(),Getdate()),
	(83,19,3,'Erros diversos',1,1,Getdate(),Getdate()),
	(84,19,4,'Dificuldade de navegação e acesso às funções',1,1,Getdate(),Getdate()),
	(85,19,5,'Não tive dificuldades',1,1,Getdate(),Getdate()),
	--Questão 20
	(91,20,1,'Com certeza. O aplicativo é muito útil',1,1,Getdate(),Getdate()),
	(92,20,2,'Sim',1,1,Getdate(),Getdate()),
	(93,20,3,'Talvez. Depende da necessidade',1,1,Getdate(),Getdate()),
	(94,20,4,'Não',1,1,Getdate(),Getdate()),
	(95,20,5,'Jamais. O aplicativo não é relevante para outras empresas',1,1,Getdate(),Getdate())
GO

DBCC CHECKIDENT('[Options]', RESEED)
GO

SET IDENTITY_INSERT Options OFF
GO

Select * From questions
Select * From options
Select * From responses