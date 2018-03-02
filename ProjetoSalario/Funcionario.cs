using System;

namespace ProjetoSalario
{
    class Funcionario
    {
        private static readonly int PORCENTAGEM_COMISSAO = 1;
        private static readonly int PORCENTAGEM_IMPOSTO = 3;
        private static readonly int VALOR_AJUDA_CUSTO = 200;
        private static readonly int VALOR_VALE_TRANSPORTE = 50;

        public string nome { get; set; }
        public double salarioBruto { get; set; }
        public double adicionais { get; private set; }
        public double descontos { get; private set; }

        private Boolean imposto;

        public Boolean impostoProp
        {
            get { return imposto; }
            set
            {
                this.imposto = value;
                calcularDescontos();
            }
        }

        private Boolean valeTransporte;

        public Boolean valeTransporteProp
        {
            get { return this.valeTransporte; }
            set
            {
                this.valeTransporte = value;
                calcularDescontos();
            }
        }

        private Boolean comissao;

        public Boolean comissaoProp
        {
            get { return this.comissao; }
            set
            {
                this.comissao = value;
                calcularAdicionais();
            }
        }

        private Boolean ajudaCusto;

        public Boolean ajudaCustoProp
        {
            get { return ajudaCusto; }
            set
            {
                this.ajudaCusto = value;
                calcularAdicionais();
            }
        }

        private double salarioLiquido;

        public double salarioLiquidoProp
        {
            get { return this.salarioBruto + this.adicionais - this.descontos; }
            set { salarioLiquido = value; }
        }

        private void calcularDescontos()
        {
            this.descontos = 0;

            if (this.valeTransporte)
            {
                this.descontos += VALOR_VALE_TRANSPORTE;
            }

            if (this.imposto)
            {
                this.descontos += (this.salarioBruto / 100 * PORCENTAGEM_IMPOSTO);
            }
        }

        private void calcularAdicionais()
        {
            this.adicionais = 0;

            if (this.ajudaCusto)
            {
                this.adicionais += VALOR_AJUDA_CUSTO;
            }

            if (this.comissao)
            {
                this.adicionais += (this.salarioBruto / 100 * PORCENTAGEM_COMISSAO);
            }
        }
    }
}