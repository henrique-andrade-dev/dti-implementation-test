﻿using dti_implementation_test.Application;
using dti_implementation_test.Utils;
using System;
using System.Collections.Generic;

namespace dti_implementation_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Input input = FillInput();
            List<PetShop> petShops = CreatePetShops(input);
            Catalog catalog = FillCatalog(petShops);

            WriteBestPetShop(catalog);

            Console.ReadKey();
        }

        static List<PetShop> CreatePetShops(Input input)
        {
            MeuCaninoFeliz meuCaninoFeliz = new MeuCaninoFeliz("Meu Canino Felix", 2000, input);
            VaiRex vaiRex = new VaiRex("Vai Rex", 1700, input);
            ChowChawgas chowChawgas = new ChowChawgas("Chow Chawgas", 800, input);
            List<PetShop> petShops = new List<PetShop>
            {
                meuCaninoFeliz,
                vaiRex,
                chowChawgas
            };

            return petShops;
        }

        static Catalog FillCatalog(List<PetShop> petShops)
        {
            Catalog catalog = new Catalog();

            foreach (PetShop petShop in petShops)
            {
                catalog.AddPetShop(petShop);
            }

            return catalog;
        }

        static Input FillInput()
        {
            Input input = new Input();

            //input.GetType().GetFields();

            do
            {
                Console.Write("Informe a data do banho (ex: 3/8/2018): ");
                input.SetDate(Console.ReadLine());

                if (!input.IsParseSuccess)
                {
                    Console.Clear();
                    Console.WriteLine("Data inválida, por favor insira uma data no formato dd-MM-yyyy.");
                }
            } while (!input.IsParseSuccess);

            do
            {
                Console.Write("Informe a quantidade de cães pequenos: ");
                input.SetSmallDogs(Console.ReadLine());

                if (!input.IsParseSuccess)
                {
                    Console.Clear();

                    Console.WriteLine("Valor inválido, por favor insira um número inteiro.");
                }
            } while (!input.IsParseSuccess);

            do
            {
                Console.Write("Informe a quantidade de cães grandes: ");
                input.SetLargeDogs(Console.ReadLine());

                if (!input.IsParseSuccess)
                {
                    Console.Clear();
                    Console.WriteLine("Valor inválido, por favor insira um número inteiro.");
                }
            } while (!input.IsParseSuccess);

            return input;

            // return new Input(date, smallDogs, largeDogs);
        }

        static void WriteBestPetShop(Catalog catalog)
        {
            PetShop bestPetShop = catalog.GetBestPetShop();

            string message = (bestPetShop is null) ?
                Constant.NO_REGISTERED_PET_SHOPS_MESSAGE :
                $"The better pet shop choice is {bestPetShop.Name}.\nThe better price is {bestPetShop.Amount:C}.";

            Console.WriteLine(message);
        }
    }
}
