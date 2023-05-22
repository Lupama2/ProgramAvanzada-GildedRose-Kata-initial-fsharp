module GildedRose.UnitTests.Tests 

open GildedRose
open System.Collections.Generic
open NUnit.Framework

open GildedRose.UnitTests.Items 


[<Test>]
let ``My test`` () =
    let Items = new List<Item>()  
    Items.Add({Name = "foo"; SellIn = 0; Quality = 0})
    let app = new GildedRose(Items)
    app.UpdateQuality()
    
    let expectedItem = {Name = "foo"; SellIn = -1; Quality = 0}
    
    Assert.AreEqual(expectedItem,Items[0])

[<Test>]
let ``Calidad Luego de Vencimiento Normal`` () =
// la calidad se degrada al doble de velocidad
    let Items = new List<Item>()  
    Items.Add({Name = "foo"; SellIn = -1; Quality = 5})
    let app = new GildedRose(Items)
    app.UpdateQuality()
    
    let expectedItem = {Name = "foo"; SellIn = -2; Quality = 3}
    
    Assert.AreEqual(expectedItem,Items[0])

[<Test>]
let ``Calidad no negativa`` () =
    ``My test`` ()

[<Test>]
let ``Aged Brie incrementa su calidad no vencido`` () =
// Poner el caso en el que la fecha de vencimiento es positiva y otro en que es negativa
    let Items = new List<Item>()  
    Items.Add(agedBrie)
    let app = new GildedRose(Items)
    app.UpdateQuality()

    let expectedItem = {Name = "Aged Brie"; SellIn = 1; Quality = 1}
    
    Assert.AreEqual(expectedItem,Items[0])

[<Test>]
let ``Aged Brie incrementa su calidad vencido`` () =
// Poner el caso en el que la fecha de vencimiento es positiva y otro en que es negativa
    let Items = new List<Item>()  
    Items.Add({Name = "Aged Brie"; SellIn = -1; Quality = 1})
    let app = new GildedRose(Items)
    app.UpdateQuality()

    let expectedItem = {Name = "Aged Brie"; SellIn = -2; Quality = 3}
    
    Assert.AreEqual(expectedItem,Items[0])


// Calidad menor a 50
[<Test>]
let ``Aged Brie calidad constante en 50`` () =
// Poner el caso en el que la fecha de vencimiento es positiva y otro en que es negativa
    let Items = new List<Item>()  
    Items.Add({Name = "Aged Brie"; SellIn = -1; Quality = 50})
    let app = new GildedRose(Items)
    app.UpdateQuality()

    let expectedItem = {Name = "Aged Brie"; SellIn = -2; Quality = 50}
    
    Assert.AreEqual(expectedItem,Items[0])

[<Test>]
let ``Test sulfuras`` () =
// Poner el caso en el que la fecha de vencimiento es positiva y otro en que es negativa
    let Items = new List<Item>()  
    Items.Add(sulfuras)
    let app = new GildedRose(Items)
    app.UpdateQuality()

    let expectedItem = sulfuras
    
    Assert.AreEqual(expectedItem,Items[0])

[<Test>]
let ``Test Backstage`` () =
// Poner el caso en el que la fecha de vencimiento es positiva y otro en que es negativa
    let Items = new List<Item>()  
    Items.Add(backstagePass)
    Items.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 10; Quality = 48 })
    Items.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 5; Quality = 47 })
    Items.Add(backstagePassAfterOnDate)
    let app = new GildedRose(Items)
    app.UpdateQuality()

    let expectedItems = new List<Item>()
    expectedItems.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 14; Quality = 21 })
    expectedItems.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 9; Quality = 50 })
    expectedItems.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = 4; Quality = 50 })
    expectedItems.Add({ Name = "Backstage passes to a TAFKAL80ETC concert"; SellIn = -1; Quality = 0 })
    

    Assert.AreEqual(expectedItems,Items)

[<Test>]
// let ``Test conjurado`` () =
//     let Items = new List<Item>()  
//     // let conjured = {Name = "Conjured Mana Cake"; SellIn = 3; Quality = 6}
//     Items.Add(conjured)
//     Items.Add({Name = "Conjured Mana Cake"; SellIn = -1; Quality = 6})
//     let app = new GildedRose(Items)
//     app.UpdateQuality()

//     let expectedItem = new List<Item>()
//     expectedItem.Add({Name = "Conjured Mana Cake"; SellIn = 2; Quality = 4})
//     expectedItem.Add({Name = "Conjured Mana Cake"; SellIn = -2; Quality = 2})

//     Assert.AreEqual(expectedItem,Items[0])