using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransConta
{
    public class Conta
    {
        public Conta(TipoConta tipoconta, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoconta;
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
        }
        private TipoConta TipoConta { get; set;}
        private string Nome{ get; set; }
        private double Saldo { get; set; }
        private double Credito {get; set;}

        public bool Sacar(double ValorSaque)
        {
            if(this.Saldo - ValorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= ValorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Tipo de Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito}";
            return retorno;
        }
    }
}