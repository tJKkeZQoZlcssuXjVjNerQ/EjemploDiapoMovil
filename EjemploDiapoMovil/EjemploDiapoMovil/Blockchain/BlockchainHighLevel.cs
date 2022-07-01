﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploDiapoMovil.Blockchain
{
    public class BlockchainHighLevel
    {
        LinkedList<Block> _BlockChain;

        public LinkedList<Block> Blockchain { get {return _BlockChain;} } 

        public BlockchainHighLevel()
        {
            _BlockChain = new LinkedList<Block>();
            _BlockChain.AddLast(BlockchainLowLevel.CreateGenesisBlock());
        }

        public void AddBlock(string DataToAdd)
        {
            byte[] NewBlockHash = BlockchainLowLevel.HashBlock(_BlockChain.Last.Value.BlockHash, DataToAdd,0);
            Block NewBlock = new Block(NewBlockHash, _BlockChain.Last.Value.BlockHash, DataToAdd);
            _BlockChain.AddLast(NewBlock);
        }

        public Block FindBlock(string HashR)
        {
            //Search Through The Entire Block
            //If we don't find anything, return Null. 
            foreach(var item in Blockchain)
            {
                if (HashR.Equals(item.HashR))
                {
                    return item;
                }
            }

            return null;
        }

        public Block FindBlock(byte[] Hash)
        {
            //Search Through The Entire Block
            //If we don't find anything, return Null. 
            foreach (var item in Blockchain)
            {

                if(item.BlockHash.SequenceEqual(Hash))
                { 
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Verifys a single block
        /// </summary>
        /// <param name="BlockUnderTest"></param>
        /// <param name="PreviousBlock"></param>
        /// <param name="NextBlock"></param>
        /// <returns></returns>
        public bool VerifyBlock(Block BlockUnderTest, Block PreviousBlock, Block NextBlock)
        {
            return BlockchainLowLevel.VerifyBlock(BlockUnderTest, PreviousBlock, NextBlock);
        }
        /// <summary>
        /// This is just for the video demo and acts as a pass-though to Low-level
        /// </summary>
        /// <param name="PreviousBlockHash"></param>
        /// <param name="TransactionData"></param>
        /// <param name="Nonce"></param>
        /// <returns></returns>
        public byte[] CreateASimpleBlockHash(byte[] PreviousBlockHash, string TransactionData, int Nonce)
        {
            return BlockchainLowLevel.HashBlock(PreviousBlockHash,TransactionData,Nonce);
        }

    }
}
