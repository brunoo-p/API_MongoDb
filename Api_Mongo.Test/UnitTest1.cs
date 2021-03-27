using System;
using Xunit;
using Moq;

namespace Api_Mongo.Test
{
    public class UnitTest1
    {
        [Fact]
        public void RegistrarNovoInfectado()
        {
            var mockInfected = new Moq<IInfected>();
            //Average
            var infected = new InfectedDTO(
                cpf: "123.456.789-00",
                dataNascimento: 1997-06-03,
                sexo: "M",
                latitude: -25.2940369,
                longitude: -54.0937847
            );
            
            //Act
            var teste = mockInfected.AddInfected(infected);

            //Assert
            Assert.NotNull(teste);
            Assert.True(teste);


        }
    }
}
