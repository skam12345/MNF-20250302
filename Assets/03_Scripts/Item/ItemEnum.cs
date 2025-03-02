public class ItemEnum
{

	public enum ITEMFIELD : int
	{
		None,
		White_Diamond,
		Black_Diamond,
		Red_Diamond,
		Blue_Diamond,
		Green_Diamond,
		Yello_Diamond,
	};

	public enum ITEMINDEX : int
	{
		None = 99999999,
		Weapon = 0,
		Equiptment,
		Food,
		Quest,
		Goods,
		Read,
		Special,

		Max = 3,
		Min = 0, 
	};


	public enum WEAPONITEMINDEX : int
	{
	//	Start_1_ItemBase = 0,
	
		Star1_1_ItemSword = 1000000,
		Star1_2_ItemGreatSword,
		Star1_3_ItemSpear,
		Star1_4_ItemBow,
		Star1_5_ItemCatalyst,
		
		Star2_1_ItemSword = 2000000,
		Star2_2_ItemGreatSword,
		Star2_3_ItemSpear,
		Star2_4_ItemBow,
		Star2_5_ItemCatalyst,

		Star3_1_ItemSword = 3000000,
		Star3_2_ItemGreatSword,
		Star3_3_ItemSpear,
		Star3_4_ItemBow,
		Star3_5_ItemCatalyst,

		Star4_1_ItemSword = 4000000,
		Star4_2_ItemGreatSword,
		Star4_3_ItemSpear,
		Star4_4_ItemBow,
		Star4_5_ItemCatalyst,

		Star5_1_ItemSword = 5000000,
		Star5_2_ItemGreatSword,
		Star5_3_ItemSpear,
		Star5_4_ItemBow,
		Star5_5_ItemCatalyst,
	};

	public enum WEAPON_OPTION : int
	{
		None,
		AddDamage,
		AddWeaponAttackValue,
		AddWeaponAttackPercent,

		FireAttack,
		WaterAttack,
		IceAttack,
		GrassAttack,
		WindAttack,
		LightingAttack,
	}

	public enum EQUIPTMENTINDEX : int
	{
		Star1_Flower = 0,
		Star1_Feather,
		Star1_Hourglass,
		Star1_Glass,
		Star1_Crown,
	};

	public enum EQUIPTMENTOPTION : int
	{
		AttackValue,
		AttackPercent,
		HPValue,
		HPPercent,
		ShieldValue,
		ShieldPercent,
	};

	public enum EQUIPTMENTSET : int
	{
		None,

	}

	public enum FOODITEMINDEX : int
	{
		//Start_1_lItemBase = 0,
		Star1_BaseMeat = 0,
		Star1_BaseWater,

		//Heal, Recovery= 1000000,
		Star1_H_CookMeat = 1000000,
		
		//Respawn = 2000000,
		Star1_R_CornSoup = 2000000,

		//Attack Buff = 3000000,
		Star1_AB_EnergyBar = 3000000,

		//Shield Buff = 4000000,
		Star1_SB_CanFood = 4000000,

		//Life Buff Stamina = 5000000,
		Star1_LB_S_SportDrink = 5000000,
		
	};

	public enum FOODTYPE : short
	{
		Base = 0,
		Heal,
		Respawn,
		BuffAttack,
		BuffShield,
		BuffLife,
	}



	public enum QUESTITEMINDEX : int
	{
		//Start_1_lItemBase = 0,
		Star1_SpearManEqupit = 0,
		Star1_CubeEnterTicket,

		//Start_2_lItemBase = 1000000,
		//Start_3_lItemBase = 2000000,
		//Start_3_lItemBase = 3000000,
		//Start_3_lItemBase = 4000000,
	};

	public enum RESOURCESINDEX : int
	{
		//Start_1_lItemBase = 0,
		//Start_2_lItemBase = 1000000,
		//Start_3_lItemBase = 2000000,

		GameCrystal = 0,
		CashCrystal,

		Special_Ticket,
		Normal_Ticket,
		Character_LevelUp_Item_Base,
		Weapon_LevelUp_Item_Base,
	};
}