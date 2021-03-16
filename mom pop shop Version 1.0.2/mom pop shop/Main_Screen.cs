using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace mom_pop_shop
{
    public partial class Main_Screen : Form
    {
        MomAndPopDatabaseDataSetTableAdapters.StartersTableAdapter STA = new MomAndPopDatabaseDataSetTableAdapters.StartersTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.SaladsTableAdapter saladsTable = new MomAndPopDatabaseDataSetTableAdapters.SaladsTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.New_York_Style_PizzaTableAdapter NYSP = new MomAndPopDatabaseDataSetTableAdapters.New_York_Style_PizzaTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.BeveragesTableAdapter BTA = new MomAndPopDatabaseDataSetTableAdapters.BeveragesTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.CalzonesTableAdapter CTA = new MomAndPopDatabaseDataSetTableAdapters.CalzonesTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.DessertsTableAdapter DTA = new MomAndPopDatabaseDataSetTableAdapters.DessertsTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.Kids_MenuTableAdapter KMTA = new MomAndPopDatabaseDataSetTableAdapters.Kids_MenuTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.Lunch_SpecialsTableAdapter LSTA = new MomAndPopDatabaseDataSetTableAdapters.Lunch_SpecialsTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.Oven_Baked_Subs_and_WrapsTableAdapter OBSWTA = new MomAndPopDatabaseDataSetTableAdapters.Oven_Baked_Subs_and_WrapsTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.Specialty_PizzasTableAdapter SPTA = new MomAndPopDatabaseDataSetTableAdapters.Specialty_PizzasTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.StromboliTableAdapter SITA = new MomAndPopDatabaseDataSetTableAdapters.StromboliTableAdapter();
        MomAndPopDatabaseDataSetTableAdapters.CustomersTableAdapter CustomersTableAdapter = new MomAndPopDatabaseDataSetTableAdapters.CustomersTableAdapter();

        public string itemName;
        public decimal Cost;

        public string extraSaladMeat;

        public string pizzaExtra;

        public decimal FinalTotal;

        public decimal RegularToppingsPriceSlice;
        public decimal RegularToppingsPrice12;
        public decimal RegularToppingsPrice16;
        public decimal RegularToppingsPriceGFree10;

        public decimal SpecialtyToppingPriceSlice;
        public decimal SpecialtyToppingPrice12;
        public decimal SpecialtyToppingPrice16;
        public decimal SpecialtyToppingPriceGFree10;


        public decimal PremiumToppingPriceSlice;
        public decimal PremiumToppingPrice12;
        public decimal PremiumToppingPrice16;
        public decimal PremiumToppingPriceGFree10;


        public Main_Screen()
        {
            InitializeComponent();

            SaladSizes.SelectedIndex = 0;
            ExtraMeatSalad.SelectedIndex = 0;
            WingType.SelectedIndex = 0;
            Flavors.SelectedIndex = 0;
            SpecialtyPizzaType.SelectedIndex = 2;
            SetPrices();
            
        }

        public void SetPrices()
        {
            RegularToppingsPriceSlice = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Regular Toppings by slice"));
            RegularToppingsPrice12 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Regular Toppings 12"));
            RegularToppingsPrice16 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Regular Toppings 16"));
            RegularToppingsPriceGFree10 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Regular Toppings Gluten Free"));

            SpecialtyToppingPriceSlice = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Specialty Toppings by Slice"));
            SpecialtyToppingPrice12 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Specialty Toppings 12"));
            SpecialtyToppingPrice16 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Specialty Toppings 16"));
            SpecialtyToppingPriceGFree10 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Specialty Toppings Gluten Free"));

            PremiumToppingPriceSlice = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Premium Toppings by Slice"));
            PremiumToppingPrice12 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Premium Toppings 12"));
            PremiumToppingPrice16 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Premium Toppings 16"));
            PremiumToppingPriceGFree10 = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice("Premium Toppings Gluten Free"));

        }

        private void Total_Click(object sender, EventArgs e)
        {

            TotalLabel.Text = Convert.ToString(FinalTotal);
            TotalMenu.Enabled = true;
            TotalMenu.BringToFront();
            listView1.SendToBack();
        }

        private void Clear()
        {
            TotalMenu.Enabled = false;
            TotalLabel.Text = "";
            FinalTotal = 0;
            CustomerName.Text = "";
            listView1.Items.Clear();
            TotalMenu.SendToBack();
        }

        private void remove_button_Click(object sender, EventArgs e)
        {
            try
            {
                decimal money;
                money = Convert.ToDecimal(listView1.SelectedItems[0].SubItems[2].Text);

                /*money = Convert.ToDecimal(saladsTable.SaladsGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(STA.StartersGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(BTA.BeveragesGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(CTA.CalzonesGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(DTA.DessertsGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(KMTA.KidsMenuGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(LSTA.LunchSpecialGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(OBSWTA.OvenBakedSubsandWrapsGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(SPTA.SpecialtyPizzasGetPrice(listView1.SelectedItems[0].Text));
                money = Convert.ToDecimal(SITA.StromboliGetPrice(listView1.SelectedItems[0].Text));*/
                FinalTotal = FinalTotal - money;
                listView1.SelectedItems[0].Remove();
            }
            catch
            {

            }
        }

        public void starterSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(STA.StartersGetPrice(name));
        }
        private void starterAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("none");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        private void wingsAdd(string word, string flavor, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add(flavor);
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void saladSearch(string name, string extra)
        {
            if (extra == "None")
            {
                itemName = name;
                Cost = Convert.ToDecimal(saladsTable.SaladsGetPrice(name));
            }
            else
            {
                itemName = name;
                Cost = Convert.ToDecimal(saladsTable.SaladsGetPrice(name));
                extraSaladMeat = Convert.ToString(ExtraMeatSalad.SelectedItem);
            }
        }
        private void saladAdd(string word, string extra, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add(extra);
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void newYorkStylePizzaSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(NYSP.NewYorkStylePizzaGetPrice(name));
        }

        private void newYorkStylePizzaAdd(string word, int extra, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add(Convert.ToString(extra));
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void specialtyPizzaSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(SPTA.SpecialtyPizzasGetPrice(name));
        }

        private void specialtyPizzaAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void kidsMenuSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(KMTA.KidsMenuGetPrice(name));
        }

        private void kidsMenuAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void beveragesSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(BTA.BeveragesGetPrice(name));
        }

        private void beveragesAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void lunchSpecialsSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(LSTA.LunchSpecialGetPrice(name));
        }

        private void lunchSpecialsAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void calzoneSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(CTA.CalzonesGetPrice(name));
        }

        private void calzoneAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void stromboliSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(SITA.StromboliGetPrice(name));
        }

        private void stromboliAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void dessertsSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(DTA.DessertsGetPrice(name));
        }

        private void dessertsAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        public void subsSearch(string name)
        {
            itemName = name;
            Cost = Convert.ToDecimal(OBSWTA.OvenBakedSubsandWrapsGetPrice(name));
        }

        private void subsAdd(string word, decimal money)
        {
            ListViewItem lvi = new ListViewItem(word);
            lvi.SubItems.Add("None");
            lvi.SubItems.Add(Convert.ToString(money));
            listView1.Items.Add(lvi);
            FinalTotal = FinalTotal + money;
        }

        //STARTERS

        private void MiniGarlicKnots_Click(object sender, EventArgs e)
        {
            starterSearch(MiniGarlicKnots.Text);
            starterAdd(itemName, Cost);
        }

        private void MiniGarlicKnotswithCheese_Click(object sender, EventArgs e)
        {
            starterSearch(MiniGarlicKnotswithCheese.Text);
            starterAdd(itemName, Cost);

        }

        private void GarlicBreadWithMarinara_Click(object sender, EventArgs e)
        {
            starterSearch(GarlicBreadWithMarinara.Text);
            starterAdd(itemName, Cost);
        }

        private void GarlicBreadwithcheeseMarinara_Click(object sender, EventArgs e)
        {
            starterSearch(GarlicBreadwithcheeseMarinara.Text);
            starterAdd(itemName, Cost);
        }

        private void InsalataCaprese_Click(object sender, EventArgs e)
        {
            starterSearch(InsalataCaprese.Text);
            starterAdd(itemName, Cost);
        }

        private void BaconCheeseFries_Click(object sender, EventArgs e)
        {
            starterSearch(BaconCheeseFries.Text);
            starterAdd(itemName, Cost);
        }

        private void FriedMozzarellaStickswithMarinara_Click(object sender, EventArgs e)
        {
            starterSearch(FriedMozzarellaStickswithMarinara.Text);
            starterAdd(itemName, Cost);
        }

        private void CheeseBreadStixwithMarinara_Click(object sender, EventArgs e)
        {
            starterSearch(CheeseBreadStixwithMarinara.Text);
            starterAdd(itemName, Cost);
        }

        //WINGS

        private void Wings10_Click(object sender, EventArgs e)
        {
            starterSearch(Wings10.Text);
            wingsAdd(itemName, Flavors.SelectedItem + " " + WingType.SelectedItem, Cost);
        }

        private void Wings20_Click(object sender, EventArgs e)
        {
            starterSearch(Wings20.Text);
            wingsAdd(itemName, Flavors.SelectedItem + " " + WingType.SelectedItem, Cost);
        }

        private void BonelessWings10_Click(object sender, EventArgs e)
        {
            starterSearch(BonelessWings10.Text);
            wingsAdd(itemName, Flavors.SelectedItem + " " + WingType.SelectedItem, Cost);
        }

        private void ExtraDressing_Click(object sender, EventArgs e)
        {
            starterSearch(ExtraDressing.Text);
            starterAdd(itemName, Cost);
        }

        //SALADS

        private void GardenSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + GardenSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat, Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + GardenSalad.Text, "None");
                saladAdd(itemName, "None" , Cost);
            }
        }

        private void GreekSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + GreekSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat, Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + GreekSalad.Text, "None");
                saladAdd(itemName, "None", Cost);
            }
        }

        private void CaesarSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + CaesarSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat, Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + CaesarSalad.Text, "None");
                saladAdd(itemName, "None", Cost);
            }
        }

        private void ChefSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + ChefSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat, Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + ChefSalad.Text, "None");
                saladAdd(itemName, "None", Cost);
            }
        }

        private void ChickenCaesarSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + ChickenCaesarSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat, Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + ChickenCaesarSalad.Text, "None");
                saladAdd(itemName, "None", Cost);
            }
        }

        private void FreshSpinachSalad_Click(object sender, EventArgs e)
        {
            if (ExtraMeatSalad.SelectedIndex > 0)
            {
                saladSearch(SaladSizes.SelectedItem + " " + FreshSpinachSalad.Text, Convert.ToString(ExtraMeatSalad.SelectedItem));
                saladAdd(itemName, extraSaladMeat , Cost);
            }
            else
            {
                saladSearch(SaladSizes.SelectedItem + " " + FreshSpinachSalad.Text, "None");
                saladAdd(itemName, "None", Cost);
            }
        }

        //REGULAR PIZZA

        private void PizzabytheSlice_Click(object sender, EventArgs e)
        {
            newYorkStylePizzaSearch(PizzabytheSlice.Text);
            newYorkStylePizzaAdd(itemName, RegularToppings.SelectedItems.Count + SpecialtyToppings.SelectedItems.Count + PremiumToppings.SelectedItems.Count,Cost + (RegularToppings.SelectedItems.Count * RegularToppingsPriceSlice) + (SpecialtyToppings.SelectedItems.Count * SpecialtyToppingPriceSlice) + (PremiumToppings.SelectedItems.Count * PremiumToppingPriceSlice));

        }

        private void medium12Pizza_Click(object sender, EventArgs e)
        {
            newYorkStylePizzaSearch(medium12Pizza.Text);
            newYorkStylePizzaAdd(itemName, RegularToppings.SelectedItems.Count + SpecialtyToppings.SelectedItems.Count + PremiumToppings.SelectedItems.Count, Cost + (RegularToppings.SelectedItems.Count * RegularToppingsPrice12) + (SpecialtyToppings.SelectedItems.Count * SpecialtyToppingPrice12) + (PremiumToppings.SelectedItems.Count * PremiumToppingPrice12));
        }

        private void large16Pizza_Click(object sender, EventArgs e)
        {
            newYorkStylePizzaSearch(large16Pizza.Text);
            newYorkStylePizzaAdd(itemName, RegularToppings.SelectedItems.Count + SpecialtyToppings.SelectedItems.Count + PremiumToppings.SelectedItems.Count, Cost + (RegularToppings.SelectedItems.Count * RegularToppingsPrice16) + (SpecialtyToppings.SelectedItems.Count * SpecialtyToppingPrice16) + (PremiumToppings.SelectedItems.Count * PremiumToppingPrice16));
        }

        private void glutenFree10Pizza_Click(object sender, EventArgs e)
        {
            newYorkStylePizzaSearch(glutenFree10Pizza.Text);
            newYorkStylePizzaAdd(itemName, RegularToppings.SelectedItems.Count + SpecialtyToppings.SelectedItems.Count + PremiumToppings.SelectedItems.Count, Cost + (RegularToppings.SelectedItems.Count * RegularToppingsPriceGFree10) + (SpecialtyToppings.SelectedItems.Count * SpecialtyToppingPriceGFree10) + (PremiumToppings.SelectedItems.Count * PremiumToppingPriceGFree10));
        }

        //SPECIALTY PIZZA

        private void Deluxe_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(Deluxe.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void ItalianSpecial_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(ItalianSpecial.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void FourCheese_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(FourCheese.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void VeggieDeluxe_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(VeggieDeluxe.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void MargheritaPizza_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(MargheritaPizza.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void MeatDeluxe_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(MeatDeluxe.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void HawaiianLuau_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(HawaiianLuau.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void TheGourmet_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(TheGourmet.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void WhitePizza_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(WhitePizza.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void TheGreatWhite_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(TheGreatWhite.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void SteakandCheesePizza_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(SteakandCheesePizza.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void ChickenRanch_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(ChickenRanch.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void ChickenFlorentine_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(ChickenFlorentine.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void BBQChicken_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(BBQChicken.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void BuffaloChickenPizza_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(BuffaloChickenPizza.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }

        private void GarlicPizza_Click(object sender, EventArgs e)
        {
            specialtyPizzaSearch(GarlicPizza.Text + " " + SpecialtyPizzaType.SelectedItem);
            specialtyPizzaAdd(itemName, Cost);
        }


        //KIDS MENU

        private void ChildSpaghetti_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(ChildSpaghetti.Text);
            kidsMenuAdd(itemName, Cost);
        }

        private void ChickenBiteswithFries_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(ChickenBiteswithFries.Text);
            kidsMenuAdd(itemName, Cost);
        }

        private void Meatballs3withMelted_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(Meatballs3withMelted.Text);
            kidsMenuAdd(itemName, Cost);
        }

        private void ChildSpaghettiwithaMeatball_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(ChildSpaghettiwithaMeatball.Text);
            kidsMenuAdd(itemName, Cost);
        }

        private void ChildPenneAlfredo_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(ChildPenneAlfredo.Text);
            kidsMenuAdd(itemName, Cost);
        }

        private void ChildRavioli_Click(object sender, EventArgs e)
        {
            kidsMenuSearch(ChildRavioli.Text);
            kidsMenuAdd(itemName, Cost);
        }

        //BEVERAGES

        private void CocaCola_Click(object sender, EventArgs e)
        {
            beveragesSearch(CocaCola.Text);
            beveragesAdd(itemName, Cost);
        }

        private void CocaColaZero_Click(object sender, EventArgs e)
        {
            beveragesSearch(CocaColaZero.Text);
            beveragesAdd(itemName, Cost);
        }

        private void DietCoke_Click(object sender, EventArgs e)
        {
            beveragesSearch(DietCoke.Text);
            beveragesAdd(itemName, Cost);
        }

        private void CocaColaCherry_Click(object sender, EventArgs e)
        {
            beveragesSearch(CocaColaCherry.Text);
            beveragesAdd(itemName, Cost);
        }

        private void Sprite_Click(object sender, EventArgs e)
        {
            beveragesSearch(Sprite.Text);
            beveragesAdd(itemName, Cost);
        }

        private void DrPepper_Click(object sender, EventArgs e)
        {
            beveragesSearch(DrPepper.Text);
            beveragesAdd(itemName, Cost);
        }

        private void HiC_Click(object sender, EventArgs e)
        {
            beveragesSearch(HiC.Text);
            beveragesAdd(itemName, Cost);
        }

        private void Barqs_Click(object sender, EventArgs e)
        {
            beveragesSearch(Barqs.Text);
            beveragesAdd(itemName, Cost);
        }

        //LUNCH SPECIALS

        private void Special1_Click(object sender, EventArgs e)
        {
            lunchSpecialsSearch(Special1.Text);
            lunchSpecialsAdd(itemName, Cost);
        }

        private void Special2_Click(object sender, EventArgs e)
        {
            lunchSpecialsSearch(Special2.Text);
            lunchSpecialsAdd(itemName, Cost);
        }

        private void Special3_Click(object sender, EventArgs e)
        {
            lunchSpecialsSearch(Special3.Text);
            lunchSpecialsAdd(itemName, Cost);
        }

        private void Special4_Click(object sender, EventArgs e)
        {
            lunchSpecialsSearch(Special4.Text);
            lunchSpecialsAdd(itemName, Cost);
        }

        private void Special5_Click(object sender, EventArgs e)
        {
            lunchSpecialsSearch(Special5.Text);
            lunchSpecialsAdd(itemName, Cost);
        }


        //CALZONES

        private void CalzoneItalianSpecial_Click(object sender, EventArgs e)
        {
            calzoneSearch(CalzoneItalianSpecial.Text);
            calzoneAdd(itemName, Cost);
        }

        private void CalzoneMeatDeluxe_Click(object sender, EventArgs e)
        {
            calzoneSearch(CalzoneMeatDeluxe.Text);
            calzoneAdd(itemName, Cost);
        }

        private void CheeseCalzone_Click(object sender, EventArgs e)
        {
            calzoneSearch(CheeseCalzone.Text);
            calzoneAdd(itemName, Cost);
        }

        private void ExtraMarinara_Click(object sender, EventArgs e)
        {
            calzoneSearch(ExtraMarinara.Text);
            calzoneAdd(itemName, Cost);
        }


        //STROMBOLIS

        private void Traditional_Click(object sender, EventArgs e)
        {
            stromboliSearch(Traditional.Text);
            stromboliAdd(itemName, Cost);
        }

        private void HouseStromboli_Click(object sender, EventArgs e)
        {
            stromboliSearch(HouseStromboli.Text);
            stromboliAdd(itemName, Cost);
        }

        private void SyracuseStuffer_Click(object sender, EventArgs e)
        {
            stromboliSearch(SyracuseStuffer.Text);
            stromboliAdd(itemName, Cost);
        }

        private void CheeseStromboli_Click(object sender, EventArgs e)
        {
            stromboliSearch(CheeseStromboli.Text);
            stromboliAdd(itemName, Cost);
        }

        private void ExtraSauce_Click(object sender, EventArgs e)
        {
            stromboliSearch(ExtraSauce.Text);
            stromboliAdd(itemName, Cost);
        }


        //DESSERTS

        private void Cheesecake_Click(object sender, EventArgs e)
        {
            dessertsSearch(Cheesecake.Text);
            dessertsAdd(itemName, Cost);
        }

        private void CinnamonKnots_Click(object sender, EventArgs e)
        {
            dessertsSearch(CinnamonKnots.Text);
            dessertsAdd(itemName, Cost);
        }


        //SUBS & WRAPS

        private void BuffaloChickenWrap_Click(object sender, EventArgs e)
        {
            subsSearch(BuffaloChickenWrap.Text);
            subsAdd(itemName, Cost);
        }

        private void HamSub_Click(object sender, EventArgs e)
        {
            subsSearch(HamSub.Text);
            subsAdd(itemName, Cost);
        }

        private void TurkeySub_Click(object sender, EventArgs e)
        {
            subsSearch(TurkeySub.Text);
            subsAdd(itemName, Cost);
        }

        private void SteakandCheeseSub_Click(object sender, EventArgs e)
        {
            subsSearch(SteakandCheeseSub.Text);
            subsAdd(itemName, Cost);
        }

        private void VeggieSub_Click(object sender, EventArgs e)
        {
            subsSearch(VeggieSub.Text);
            subsAdd(itemName, Cost);
        }

        private void ChickenPhillySub_Click(object sender, EventArgs e)
        {
            subsSearch(ChickenPhillySub.Text);
            subsAdd(itemName, Cost);
        }

        private void ChickenParmigianaSub_Click(object sender, EventArgs e)
        {
            subsSearch(ChickenParmigianaSub.Text);
            subsAdd(itemName, Cost);
        }

        private void MeatballParmigianaSub_Click(object sender, EventArgs e)
        {
            subsSearch(MeatballParmigianaSub.Text);
            subsAdd(itemName, Cost);
        }

        private void EggplantParmigianaSub_Click(object sender, EventArgs e)
        {
            subsSearch(EggplantParmigianaSub.Text);
            subsAdd(itemName, Cost);
        }

        private void SausageParmigianaSub_Click(object sender, EventArgs e)
        {
            subsSearch(SausageParmigianaSub.Text);
            subsAdd(itemName, Cost);
        }



        //CHECK OUT BUTTONS

        private void CashButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CreditCardButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            Clear();
        }


        //CUSTOMER LOOKUP

        private void CustomerLookup_Click(object sender, EventArgs e)
        {
            CustomerName.Text = Convert.ToString(CustomersTableAdapter.CustomerLookup(PhoneNumber.Text));
        }

        private void AddCustomer_Click(object sender, EventArgs e)
        {
            CustomersTableAdapter.InsertCustomers(AddNameCustomer.Text, PhoneNumber.Text);
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.momAndPopDatabaseDataSet);

        }

        private void Main_Screen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'momAndPopDatabaseDataSet.Customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter1.Fill(this.momAndPopDatabaseDataSet.Customers);

        }
    }
}
