﻿using CardanoSharp.Wallet.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardanoSharp.Wallet.TransactionBuilding
{
    public interface ITransactionBuilder: IABuilder<Transaction>
    {
        ITransactionBuilder SetBody(ITransactionBodyBuilder bodyBuilder);
        ITransactionBuilder SetWitnesses(ITransactionWitnessSetBuilder witnessBuilder);
        ITransactionBuilder SetAuxData(IAuxiliaryDataBuilder auxDataBuilder);
    }

    public partial class TransactionBuilder : ABuilder<Transaction>, ITransactionBuilder
    {
        private TransactionBuilder()
        {
            _model = new Transaction();
        }

        public static ITransactionBuilder Create
        {
            get => new TransactionBuilder();
        }

        public ITransactionBuilder SetAuxData(IAuxiliaryDataBuilder auxDataBuilder)
        {
            _model.AuxiliaryData = auxDataBuilder.Build();
            return this;
        }

        public ITransactionBuilder SetBody(ITransactionBodyBuilder bodyBuilder)
        {
            _model.TransactionBody = bodyBuilder.Build();
            return this;
        }

        public ITransactionBuilder SetWitnesses(ITransactionWitnessSetBuilder witnessBuilder)
        {
            _model.TransactionWitnessSet = witnessBuilder.Build();
            return this;
        }
    }
}
