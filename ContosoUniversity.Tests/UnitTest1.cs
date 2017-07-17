using System;
using System.Collections.Generic;
using Xunit;
namespace ContosoUniversity.Tests
{
   
    public class UnitTest1
    {
            [Fact]
            public void TestUntukFungsiElement1()
            {

                var hasilYangSayaHarap = "Sumatera";

                Assert.Equal(hasilYangSayaHarap, Element1(ReturnPulau()));
            }

            [Fact]
            public void TestUntukFungsiElementTerakhir()
            {

                var hasilYangSayaHarap = "Bali";

                Assert.Equal(hasilYangSayaHarap, ElementTerakhir(ReturnPulau()));
            }

            [Fact]
            public void TestUntukFungsiElementTengah()
            {

                var hasilYangSayaHarap = "Kalimantan";

                Assert.Equal(hasilYangSayaHarap, ElementTengah(ReturnPulau()));
            }

            public List<string> ReturnPulau()
            {
                var a = new List<string>() {
                "Sumatera", "Jawa", "Kalimantan", "Papua", "Bali"
            };
                return a;
            }

            public string Element1(List<string> list)
            {
                return list[0];
            }

            public string ElementTerakhir(List<string> list)
            {
                return list[list.Count - 1];
            }

            public string ElementTengah(List<string> list)
            {
                var a = list.Count;
                if (a % 2 == 0)
                {
                    return list[(a / 2) - 1];
                }
                else
                {
                    decimal b = list.Count / 2;
                    var angkaRounded = Math.Ceiling(b);
                    return list[Convert.ToInt32(angkaRounded)];
                }

                //decimal b = list.Count / 2;
                //var angkaRounded = Math.Ceiling(b);
                //return list[Convert.ToInt32(angkaRounded)];

            }
        }


    }
