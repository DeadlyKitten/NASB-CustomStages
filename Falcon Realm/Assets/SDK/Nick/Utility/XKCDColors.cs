using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class XKCDColors
{
	internal class ColorTranslator
	{
		public static Color FromHtml(string hexString)
		{
			return new Color((float)Convert.ToInt32(hexString.Substring(1, 2), 16) / 255f, (float)Convert.ToInt32(hexString.Substring(3, 2), 16) / 255f, (float)Convert.ToInt32(hexString.Substring(5, 2), 16) / 255f);
		}
	}

	private static Color[] allColors;

	private static uint[] primes = new uint[200]
	{
		2u, 3u, 5u, 7u, 11u, 13u, 17u, 19u, 23u, 29u,
		31u, 37u, 41u, 43u, 47u, 53u, 59u, 61u, 67u, 71u,
		73u, 79u, 83u, 89u, 97u, 101u, 103u, 107u, 109u, 113u,
		127u, 131u, 137u, 139u, 149u, 151u, 157u, 163u, 167u, 173u,
		179u, 181u, 191u, 193u, 197u, 199u, 211u, 223u, 227u, 229u,
		233u, 239u, 241u, 251u, 257u, 263u, 269u, 271u, 277u, 281u,
		283u, 293u, 307u, 311u, 313u, 317u, 331u, 337u, 347u, 349u,
		353u, 359u, 367u, 373u, 379u, 383u, 389u, 397u, 401u, 409u,
		419u, 421u, 431u, 433u, 439u, 443u, 449u, 457u, 461u, 463u,
		467u, 479u, 487u, 491u, 499u, 503u, 509u, 521u, 523u, 541u,
		547u, 557u, 563u, 569u, 571u, 577u, 587u, 593u, 599u, 601u,
		607u, 613u, 617u, 619u, 631u, 641u, 643u, 647u, 653u, 659u,
		661u, 673u, 677u, 683u, 691u, 701u, 709u, 719u, 727u, 733u,
		739u, 743u, 751u, 757u, 761u, 769u, 773u, 787u, 797u, 809u,
		811u, 821u, 823u, 827u, 829u, 839u, 853u, 857u, 859u, 863u,
		877u, 881u, 883u, 887u, 907u, 911u, 919u, 929u, 937u, 941u,
		947u, 953u, 967u, 971u, 977u, 983u, 991u, 997u, 1009u, 1013u,
		1019u, 1021u, 1031u, 1033u, 1039u, 1049u, 1051u, 1061u, 1063u, 1069u,
		1087u, 1091u, 1093u, 1097u, 1103u, 1109u, 1117u, 1123u, 1129u, 1151u,
		1153u, 1163u, 1171u, 1181u, 1187u, 1193u, 1201u, 1213u, 1217u, 1223u
	};

	private static Color[] AllColors
	{
		get
		{
			if (allColors == null)
			{
				PropertyInfo[] properties = typeof(XKCDColors).GetProperties();
				List<Color> list = new List<Color>();
				for (int i = 0; i < properties.Length; i++)
				{
					if (properties[i].PropertyType == typeof(Color))
					{
						list.Add((Color)properties[i].GetGetMethod().Invoke(null, new object[0]));
					}
				}
				allColors = list.ToArray();
			}
			return allColors;
		}
	}

	public static Color CloudyBlue => ColorTranslator.FromHtml("#acc2d9");

	public static Color DarkPastelGreen => ColorTranslator.FromHtml("#56ae57");

	public static Color Dust => ColorTranslator.FromHtml("#b2996e");

	public static Color ElectricLime => ColorTranslator.FromHtml("#a8ff04");

	public static Color FreshGreen => ColorTranslator.FromHtml("#69d84f");

	public static Color LightEggplant => ColorTranslator.FromHtml("#894585");

	public static Color NastyGreen => ColorTranslator.FromHtml("#70b23f");

	public static Color ReallyLightBlue => ColorTranslator.FromHtml("#d4ffff");

	public static Color Tea => ColorTranslator.FromHtml("#65ab7c");

	public static Color WarmPurple => ColorTranslator.FromHtml("#952e8f");

	public static Color YellowishTan => ColorTranslator.FromHtml("#fcfc81");

	public static Color Cement => ColorTranslator.FromHtml("#a5a391");

	public static Color DarkGrassGreen => ColorTranslator.FromHtml("#388004");

	public static Color DustyTeal => ColorTranslator.FromHtml("#4c9085");

	public static Color GreyTeal => ColorTranslator.FromHtml("#5e9b8a");

	public static Color MacaroniAndCheese => ColorTranslator.FromHtml("#efb435");

	public static Color PinkishTan => ColorTranslator.FromHtml("#d99b82");

	public static Color Spruce => ColorTranslator.FromHtml("#0a5f38");

	public static Color StrongBlue => ColorTranslator.FromHtml("#0c06f7");

	public static Color ToxicGreen => ColorTranslator.FromHtml("#61de2a");

	public static Color WindowsBlue => ColorTranslator.FromHtml("#3778bf");

	public static Color BlueBlue => ColorTranslator.FromHtml("#2242c7");

	public static Color BlueWithAHintOfPurple => ColorTranslator.FromHtml("#533cc6");

	public static Color Booger => ColorTranslator.FromHtml("#9bb53c");

	public static Color BrightSeaGreen => ColorTranslator.FromHtml("#05ffa6");

	public static Color DarkGreenBlue => ColorTranslator.FromHtml("#1f6357");

	public static Color DeepTurquoise => ColorTranslator.FromHtml("#017374");

	public static Color GreenTeal => ColorTranslator.FromHtml("#0cb577");

	public static Color StrongPink => ColorTranslator.FromHtml("#ff0789");

	public static Color Bland => ColorTranslator.FromHtml("#afa88b");

	public static Color DeepAqua => ColorTranslator.FromHtml("#08787f");

	public static Color LavenderPink => ColorTranslator.FromHtml("#dd85d7");

	public static Color LightMossGreen => ColorTranslator.FromHtml("#a6c875");

	public static Color LightSeafoamGreen => ColorTranslator.FromHtml("#a7ffb5");

	public static Color OliveYellow => ColorTranslator.FromHtml("#c2b709");

	public static Color PigPink => ColorTranslator.FromHtml("#e78ea5");

	public static Color DeepLilac => ColorTranslator.FromHtml("#966ebd");

	public static Color Desert => ColorTranslator.FromHtml("#ccad60");

	public static Color DustyLavender => ColorTranslator.FromHtml("#ac86a8");

	public static Color PurpleyGrey => ColorTranslator.FromHtml("#947e94");

	public static Color Purply => ColorTranslator.FromHtml("#983fb2");

	public static Color CandyPink => ColorTranslator.FromHtml("#ff63e9");

	public static Color LightPastelGreen => ColorTranslator.FromHtml("#b2fba5");

	public static Color BoringGreen => ColorTranslator.FromHtml("#63b365");

	public static Color KiwiGreen => ColorTranslator.FromHtml("#8ee53f");

	public static Color LightGreyGreen => ColorTranslator.FromHtml("#b7e1a1");

	public static Color OrangePink => ColorTranslator.FromHtml("#ff6f52");

	public static Color TeaGreen => ColorTranslator.FromHtml("#bdf8a3");

	public static Color VeryLightBrown => ColorTranslator.FromHtml("#d3b683");

	public static Color EggShell => ColorTranslator.FromHtml("#fffcc4");

	public static Color EggplantPurple => ColorTranslator.FromHtml("#430541");

	public static Color PowderPink => ColorTranslator.FromHtml("#ffb2d0");

	public static Color ReddishGrey => ColorTranslator.FromHtml("#997570");

	public static Color BabyShitBrown => ColorTranslator.FromHtml("#ad900d");

	public static Color Liliac => ColorTranslator.FromHtml("#c48efd");

	public static Color StormyBlue => ColorTranslator.FromHtml("#507b9c");

	public static Color UglyBrown => ColorTranslator.FromHtml("#7d7103");

	public static Color Custard => ColorTranslator.FromHtml("#fffd78");

	public static Color DarkishPink => ColorTranslator.FromHtml("#da467d");

	public static Color DeepBrown => ColorTranslator.FromHtml("#410200");

	public static Color GreenishBeige => ColorTranslator.FromHtml("#c9d179");

	public static Color Manilla => ColorTranslator.FromHtml("#fffa86");

	public static Color OffBlue => ColorTranslator.FromHtml("#5684ae");

	public static Color BattleshipGrey => ColorTranslator.FromHtml("#6b7c85");

	public static Color BrownyGreen => ColorTranslator.FromHtml("#6f6c0a");

	public static Color Bruise => ColorTranslator.FromHtml("#7e4071");

	public static Color KelleyGreen => ColorTranslator.FromHtml("#009337");

	public static Color SicklyYellow => ColorTranslator.FromHtml("#d0e429");

	public static Color SunnyYellow => ColorTranslator.FromHtml("#fff917");

	public static Color Azul => ColorTranslator.FromHtml("#1d5dec");

	public static Color Darkgreen => ColorTranslator.FromHtml("#054907");

	public static Color Green_Yellow => ColorTranslator.FromHtml("#b5ce08");

	public static Color Lichen => ColorTranslator.FromHtml("#8fb67b");

	public static Color LightLightGreen => ColorTranslator.FromHtml("#c8ffb0");

	public static Color PaleGold => ColorTranslator.FromHtml("#fdde6c");

	public static Color SunYellow => ColorTranslator.FromHtml("#ffdf22");

	public static Color TanGreen => ColorTranslator.FromHtml("#a9be70");

	public static Color Burple => ColorTranslator.FromHtml("#6832e3");

	public static Color Butterscotch => ColorTranslator.FromHtml("#fdb147");

	public static Color Toupe => ColorTranslator.FromHtml("#c7ac7d");

	public static Color DarkCream => ColorTranslator.FromHtml("#fff39a");

	public static Color IndianRed => ColorTranslator.FromHtml("#850e04");

	public static Color LightLavendar => ColorTranslator.FromHtml("#efc0fe");

	public static Color PoisonGreen => ColorTranslator.FromHtml("#40fd14");

	public static Color BabyPukeGreen => ColorTranslator.FromHtml("#b6c406");

	public static Color BrightYellowGreen => ColorTranslator.FromHtml("#9dff00");

	public static Color CharcoalGrey => ColorTranslator.FromHtml("#3c4142");

	public static Color Squash => ColorTranslator.FromHtml("#f2ab15");

	public static Color Cinnamon => ColorTranslator.FromHtml("#ac4f06");

	public static Color LightPeaGreen => ColorTranslator.FromHtml("#c4fe82");

	public static Color RadioactiveGreen => ColorTranslator.FromHtml("#2cfa1f");

	public static Color RawSienna => ColorTranslator.FromHtml("#9a6200");

	public static Color BabyPurple => ColorTranslator.FromHtml("#ca9bf7");

	public static Color Cocoa => ColorTranslator.FromHtml("#875f42");

	public static Color LightRoyalBlue => ColorTranslator.FromHtml("#3a2efe");

	public static Color Orangeish => ColorTranslator.FromHtml("#fd8d49");

	public static Color RustBrown => ColorTranslator.FromHtml("#8b3103");

	public static Color SandBrown => ColorTranslator.FromHtml("#cba560");

	public static Color Swamp => ColorTranslator.FromHtml("#698339");

	public static Color TealishGreen => ColorTranslator.FromHtml("#0cdc73");

	public static Color BurntSiena => ColorTranslator.FromHtml("#b75203");

	public static Color Camo => ColorTranslator.FromHtml("#7f8f4e");

	public static Color DuskBlue => ColorTranslator.FromHtml("#26538d");

	public static Color Fern => ColorTranslator.FromHtml("#63a950");

	public static Color OldRose => ColorTranslator.FromHtml("#c87f89");

	public static Color PaleLightGreen => ColorTranslator.FromHtml("#b1fc99");

	public static Color PeachyPink => ColorTranslator.FromHtml("#ff9a8a");

	public static Color RosyPink => ColorTranslator.FromHtml("#f6688e");

	public static Color LightBluishGreen => ColorTranslator.FromHtml("#76fda8");

	public static Color LightBrightGreen => ColorTranslator.FromHtml("#53fe5c");

	public static Color LightNeonGreen => ColorTranslator.FromHtml("#4efd54");

	public static Color LightSeafoam => ColorTranslator.FromHtml("#a0febf");

	public static Color TiffanyBlue => ColorTranslator.FromHtml("#7bf2da");

	public static Color WashedOutGreen => ColorTranslator.FromHtml("#bcf5a6");

	public static Color BrownyOrange => ColorTranslator.FromHtml("#ca6b02");

	public static Color NiceBlue => ColorTranslator.FromHtml("#107ab0");

	public static Color Sapphire => ColorTranslator.FromHtml("#2138ab");

	public static Color GreyishTeal => ColorTranslator.FromHtml("#719f91");

	public static Color OrangeyYellow => ColorTranslator.FromHtml("#fdb915");

	public static Color Parchment => ColorTranslator.FromHtml("#fefcaf");

	public static Color Straw => ColorTranslator.FromHtml("#fcf679");

	public static Color VeryDarkBrown => ColorTranslator.FromHtml("#1d0200");

	public static Color Terracota => ColorTranslator.FromHtml("#cb6843");

	public static Color UglyBlue => ColorTranslator.FromHtml("#31668a");

	public static Color ClearBlue => ColorTranslator.FromHtml("#247afd");

	public static Color Creme => ColorTranslator.FromHtml("#ffffb6");

	public static Color FoamGreen => ColorTranslator.FromHtml("#90fda9");

	public static Color Grey_Green => ColorTranslator.FromHtml("#86a17d");

	public static Color LightGold => ColorTranslator.FromHtml("#fddc5c");

	public static Color SeafoamBlue => ColorTranslator.FromHtml("#78d1b6");

	public static Color Topaz => ColorTranslator.FromHtml("#13bbaf");

	public static Color VioletPink => ColorTranslator.FromHtml("#fb5ffc");

	public static Color Wintergreen => ColorTranslator.FromHtml("#20f986");

	public static Color YellowTan => ColorTranslator.FromHtml("#ffe36e");

	public static Color DarkFuchsia => ColorTranslator.FromHtml("#9d0759");

	public static Color IndigoBlue => ColorTranslator.FromHtml("#3a18b1");

	public static Color LightYellowishGreen => ColorTranslator.FromHtml("#c2ff89");

	public static Color PaleMagenta => ColorTranslator.FromHtml("#d767ad");

	public static Color RichPurple => ColorTranslator.FromHtml("#720058");

	public static Color SunflowerYellow => ColorTranslator.FromHtml("#ffda03");

	public static Color Green_Blue => ColorTranslator.FromHtml("#01c08d");

	public static Color Leather => ColorTranslator.FromHtml("#ac7434");

	public static Color RacingGreen => ColorTranslator.FromHtml("#014600");

	public static Color VividPurple => ColorTranslator.FromHtml("#9900fa");

	public static Color DarkRoyalBlue => ColorTranslator.FromHtml("#02066f");

	public static Color Hazel => ColorTranslator.FromHtml("#8e7618");

	public static Color MutedPink => ColorTranslator.FromHtml("#d1768f");

	public static Color BoogerGreen => ColorTranslator.FromHtml("#96b403");

	public static Color Canary => ColorTranslator.FromHtml("#fdff63");

	public static Color CoolGrey => ColorTranslator.FromHtml("#95a3a6");

	public static Color DarkTaupe => ColorTranslator.FromHtml("#7f684e");

	public static Color DarkishPurple => ColorTranslator.FromHtml("#751973");

	public static Color TrueGreen => ColorTranslator.FromHtml("#089404");

	public static Color CoralPink => ColorTranslator.FromHtml("#ff6163");

	public static Color DarkSage => ColorTranslator.FromHtml("#598556");

	public static Color DarkSlateBlue => ColorTranslator.FromHtml("#214761");

	public static Color FlatBlue => ColorTranslator.FromHtml("#3c73a8");

	public static Color Mushroom => ColorTranslator.FromHtml("#ba9e88");

	public static Color RichBlue => ColorTranslator.FromHtml("#021bf9");

	public static Color DirtyPurple => ColorTranslator.FromHtml("#734a65");

	public static Color Greenblue => ColorTranslator.FromHtml("#23c48b");

	public static Color IckyGreen => ColorTranslator.FromHtml("#8fae22");

	public static Color LightKhaki => ColorTranslator.FromHtml("#e6f2a2");

	public static Color WarmBlue => ColorTranslator.FromHtml("#4b57db");

	public static Color DarkHotPink => ColorTranslator.FromHtml("#d90166");

	public static Color DeepSeaBlue => ColorTranslator.FromHtml("#015482");

	public static Color Carmine => ColorTranslator.FromHtml("#9d0216");

	public static Color DarkYellowGreen => ColorTranslator.FromHtml("#728f02");

	public static Color PalePeach => ColorTranslator.FromHtml("#ffe5ad");

	public static Color PlumPurple => ColorTranslator.FromHtml("#4e0550");

	public static Color GoldenRod => ColorTranslator.FromHtml("#f9bc08");

	public static Color NeonRed => ColorTranslator.FromHtml("#ff073a");

	public static Color OldPink => ColorTranslator.FromHtml("#c77986");

	public static Color VeryPaleBlue => ColorTranslator.FromHtml("#d6fffe");

	public static Color BloodOrange => ColorTranslator.FromHtml("#fe4b03");

	public static Color Grapefruit => ColorTranslator.FromHtml("#fd5956");

	public static Color SandYellow => ColorTranslator.FromHtml("#fce166");

	public static Color ClayBrown => ColorTranslator.FromHtml("#b2713d");

	public static Color DarkBlueGrey => ColorTranslator.FromHtml("#1f3b4d");

	public static Color FlatGreen => ColorTranslator.FromHtml("#699d4c");

	public static Color LightGreenBlue => ColorTranslator.FromHtml("#56fca2");

	public static Color WarmPink => ColorTranslator.FromHtml("#fb5581");

	public static Color DodgerBlue => ColorTranslator.FromHtml("#3e82fc");

	public static Color GrossGreen => ColorTranslator.FromHtml("#a0bf16");

	public static Color Ice => ColorTranslator.FromHtml("#d6fffa");

	public static Color MetallicBlue => ColorTranslator.FromHtml("#4f738e");

	public static Color PaleSalmon => ColorTranslator.FromHtml("#ffb19a");

	public static Color SapGreen => ColorTranslator.FromHtml("#5c8b15");

	public static Color Algae => ColorTranslator.FromHtml("#54ac68");

	public static Color BlueyGrey => ColorTranslator.FromHtml("#89a0b0");

	public static Color GreenyGrey => ColorTranslator.FromHtml("#7ea07a");

	public static Color HighlighterGreen => ColorTranslator.FromHtml("#1bfc06");

	public static Color LightLightBlue => ColorTranslator.FromHtml("#cafffb");

	public static Color LightMint => ColorTranslator.FromHtml("#b6ffbb");

	public static Color RawUmber => ColorTranslator.FromHtml("#a75e09");

	public static Color VividBlue => ColorTranslator.FromHtml("#152eff");

	public static Color DeepLavender => ColorTranslator.FromHtml("#8d5eb7");

	public static Color DullTeal => ColorTranslator.FromHtml("#5f9e8f");

	public static Color LightGreenishBlue => ColorTranslator.FromHtml("#63f7b4");

	public static Color MudGreen => ColorTranslator.FromHtml("#606602");

	public static Color Pinky => ColorTranslator.FromHtml("#fc86aa");

	public static Color RedWine => ColorTranslator.FromHtml("#8c0034");

	public static Color ShitGreen => ColorTranslator.FromHtml("#758000");

	public static Color TanBrown => ColorTranslator.FromHtml("#ab7e4c");

	public static Color Darkblue => ColorTranslator.FromHtml("#030764");

	public static Color Rosa => ColorTranslator.FromHtml("#fe86a4");

	public static Color Lipstick => ColorTranslator.FromHtml("#d5174e");

	public static Color PaleMauve => ColorTranslator.FromHtml("#fed0fc");

	public static Color Claret => ColorTranslator.FromHtml("#680018");

	public static Color Dandelion => ColorTranslator.FromHtml("#fedf08");

	public static Color Orangered => ColorTranslator.FromHtml("#fe420f");

	public static Color PoopGreen => ColorTranslator.FromHtml("#6f7c00");

	public static Color Ruby => ColorTranslator.FromHtml("#ca0147");

	public static Color Dark => ColorTranslator.FromHtml("#1b2431");

	public static Color GreenishTurquoise => ColorTranslator.FromHtml("#00fbb0");

	public static Color PastelRed => ColorTranslator.FromHtml("#db5856");

	public static Color PissYellow => ColorTranslator.FromHtml("#ddd618");

	public static Color BrightCyan => ColorTranslator.FromHtml("#41fdfe");

	public static Color DarkCoral => ColorTranslator.FromHtml("#cf524e");

	public static Color AlgaeGreen => ColorTranslator.FromHtml("#21c36f");

	public static Color DarkishRed => ColorTranslator.FromHtml("#a90308");

	public static Color ReddyBrown => ColorTranslator.FromHtml("#6e1005");

	public static Color BlushPink => ColorTranslator.FromHtml("#fe828c");

	public static Color CamouflageGreen => ColorTranslator.FromHtml("#4b6113");

	public static Color LawnGreen => ColorTranslator.FromHtml("#4da409");

	public static Color Putty => ColorTranslator.FromHtml("#beae8a");

	public static Color VibrantBlue => ColorTranslator.FromHtml("#0339f8");

	public static Color DarkSand => ColorTranslator.FromHtml("#a88f59");

	public static Color Purple_Blue => ColorTranslator.FromHtml("#5d21d0");

	public static Color Saffron => ColorTranslator.FromHtml("#feb209");

	public static Color Twilight => ColorTranslator.FromHtml("#4e518b");

	public static Color WarmBrown => ColorTranslator.FromHtml("#964e02");

	public static Color Bluegrey => ColorTranslator.FromHtml("#85a3b2");

	public static Color BubbleGumPink => ColorTranslator.FromHtml("#ff69af");

	public static Color DuckEggBlue => ColorTranslator.FromHtml("#c3fbf4");

	public static Color GreenishCyan => ColorTranslator.FromHtml("#2afeb7");

	public static Color Petrol => ColorTranslator.FromHtml("#005f6a");

	public static Color Royal => ColorTranslator.FromHtml("#0c1793");

	public static Color Butter => ColorTranslator.FromHtml("#ffff81");

	public static Color DustyOrange => ColorTranslator.FromHtml("#f0833a");

	public static Color OffYellow => ColorTranslator.FromHtml("#f1f33f");

	public static Color PaleOliveGreen => ColorTranslator.FromHtml("#b1d27b");

	public static Color Orangish => ColorTranslator.FromHtml("#fc824a");

	public static Color Leaf => ColorTranslator.FromHtml("#71aa34");

	public static Color LightBlueGrey => ColorTranslator.FromHtml("#b7c9e2");

	public static Color DriedBlood => ColorTranslator.FromHtml("#4b0101");

	public static Color LightishPurple => ColorTranslator.FromHtml("#a552e6");

	public static Color RustyRed => ColorTranslator.FromHtml("#af2f0d");

	public static Color LavenderBlue => ColorTranslator.FromHtml("#8b88f8");

	public static Color LightGrassGreen => ColorTranslator.FromHtml("#9af764");

	public static Color LightMintGreen => ColorTranslator.FromHtml("#a6fbb2");

	public static Color Sunflower => ColorTranslator.FromHtml("#ffc512");

	public static Color Velvet => ColorTranslator.FromHtml("#750851");

	public static Color BrickOrange => ColorTranslator.FromHtml("#c14a09");

	public static Color LightishRed => ColorTranslator.FromHtml("#fe2f4a");

	public static Color PureBlue => ColorTranslator.FromHtml("#0203e2");

	public static Color TwilightBlue => ColorTranslator.FromHtml("#0a437a");

	public static Color VioletRed => ColorTranslator.FromHtml("#a50055");

	public static Color YellowyBrown => ColorTranslator.FromHtml("#ae8b0c");

	public static Color Carnation => ColorTranslator.FromHtml("#fd798f");

	public static Color MuddyYellow => ColorTranslator.FromHtml("#bfac05");

	public static Color DarkSeafoamGreen => ColorTranslator.FromHtml("#3eaf76");

	public static Color DeepRose => ColorTranslator.FromHtml("#c74767");

	public static Color DustyRed => ColorTranslator.FromHtml("#b9484e");

	public static Color Grey_Blue => ColorTranslator.FromHtml("#647d8e");

	public static Color LemonLime => ColorTranslator.FromHtml("#bffe28");

	public static Color Purple_Pink => ColorTranslator.FromHtml("#d725de");

	public static Color BrownYellow => ColorTranslator.FromHtml("#b29705");

	public static Color PurpleBrown => ColorTranslator.FromHtml("#673a3f");

	public static Color Wisteria => ColorTranslator.FromHtml("#a87dc2");

	public static Color BananaYellow => ColorTranslator.FromHtml("#fafe4b");

	public static Color LipstickRed => ColorTranslator.FromHtml("#c0022f");

	public static Color WaterBlue => ColorTranslator.FromHtml("#0e87cc");

	public static Color BrownGrey => ColorTranslator.FromHtml("#8d8468");

	public static Color VibrantPurple => ColorTranslator.FromHtml("#ad03de");

	public static Color BabyGreen => ColorTranslator.FromHtml("#8cff9e");

	public static Color BarfGreen => ColorTranslator.FromHtml("#94ac02");

	public static Color EggshellBlue => ColorTranslator.FromHtml("#c4fff7");

	public static Color SandyYellow => ColorTranslator.FromHtml("#fdee73");

	public static Color CoolGreen => ColorTranslator.FromHtml("#33b864");

	public static Color Pale => ColorTranslator.FromHtml("#fff9d0");

	public static Color Blue_Grey => ColorTranslator.FromHtml("#758da3");

	public static Color HotMagenta => ColorTranslator.FromHtml("#f504c9");

	public static Color Greyblue => ColorTranslator.FromHtml("#77a1b5");

	public static Color Purpley => ColorTranslator.FromHtml("#8756e4");

	public static Color BabyShitGreen => ColorTranslator.FromHtml("#889717");

	public static Color BrownishPink => ColorTranslator.FromHtml("#c27e79");

	public static Color DarkAquamarine => ColorTranslator.FromHtml("#017371");

	public static Color Diarrhea => ColorTranslator.FromHtml("#9f8303");

	public static Color LightMustard => ColorTranslator.FromHtml("#f7d560");

	public static Color PaleSkyBlue => ColorTranslator.FromHtml("#bdf6fe");

	public static Color TurtleGreen => ColorTranslator.FromHtml("#75b84f");

	public static Color BrightOlive => ColorTranslator.FromHtml("#9cbb04");

	public static Color DarkGreyBlue => ColorTranslator.FromHtml("#29465b");

	public static Color GreenyBrown => ColorTranslator.FromHtml("#696006");

	public static Color LemonGreen => ColorTranslator.FromHtml("#adf802");

	public static Color LightPeriwinkle => ColorTranslator.FromHtml("#c1c6fc");

	public static Color SeaweedGreen => ColorTranslator.FromHtml("#35ad6b");

	public static Color SunshineYellow => ColorTranslator.FromHtml("#fffd37");

	public static Color UglyPurple => ColorTranslator.FromHtml("#a442a0");

	public static Color MediumPink => ColorTranslator.FromHtml("#f36196");

	public static Color PukeBrown => ColorTranslator.FromHtml("#947706");

	public static Color VeryLightPink => ColorTranslator.FromHtml("#fff4f2");

	public static Color Viridian => ColorTranslator.FromHtml("#1e9167");

	public static Color Bile => ColorTranslator.FromHtml("#b5c306");

	public static Color FadedYellow => ColorTranslator.FromHtml("#feff7f");

	public static Color VeryPaleGreen => ColorTranslator.FromHtml("#cffdbc");

	public static Color VibrantGreen => ColorTranslator.FromHtml("#0add08");

	public static Color BrightLime => ColorTranslator.FromHtml("#87fd05");

	public static Color Spearmint => ColorTranslator.FromHtml("#1ef876");

	public static Color LightAquamarine => ColorTranslator.FromHtml("#7bfdc7");

	public static Color LightSage => ColorTranslator.FromHtml("#bcecac");

	public static Color Yellowgreen => ColorTranslator.FromHtml("#bbf90f");

	public static Color BabyPoo => ColorTranslator.FromHtml("#ab9004");

	public static Color DarkSeafoam => ColorTranslator.FromHtml("#1fb57a");

	public static Color DeepTeal => ColorTranslator.FromHtml("#00555a");

	public static Color Heather => ColorTranslator.FromHtml("#a484ac");

	public static Color RustOrange => ColorTranslator.FromHtml("#c45508");

	public static Color DirtyBlue => ColorTranslator.FromHtml("#3f829d");

	public static Color FernGreen => ColorTranslator.FromHtml("#548d44");

	public static Color BrightLilac => ColorTranslator.FromHtml("#c95efb");

	public static Color WeirdGreen => ColorTranslator.FromHtml("#3ae57f");

	public static Color PeacockBlue => ColorTranslator.FromHtml("#016795");

	public static Color AvocadoGreen => ColorTranslator.FromHtml("#87a922");

	public static Color FadedOrange => ColorTranslator.FromHtml("#f0944d");

	public static Color GrapePurple => ColorTranslator.FromHtml("#5d1451");

	public static Color HotGreen => ColorTranslator.FromHtml("#25ff29");

	public static Color LimeYellow => ColorTranslator.FromHtml("#d0fe1d");

	public static Color Mango => ColorTranslator.FromHtml("#ffa62b");

	public static Color Shamrock => ColorTranslator.FromHtml("#01b44c");

	public static Color Bubblegum => ColorTranslator.FromHtml("#ff6cb5");

	public static Color PurplishBrown => ColorTranslator.FromHtml("#6b4247");

	public static Color VomitYellow => ColorTranslator.FromHtml("#c7c10c");

	public static Color PaleCyan => ColorTranslator.FromHtml("#b7fffa");

	public static Color KeyLime => ColorTranslator.FromHtml("#aeff6e");

	public static Color TomatoRed => ColorTranslator.FromHtml("#ec2d01");

	public static Color Lightgreen => ColorTranslator.FromHtml("#76ff7b");

	public static Color Merlot => ColorTranslator.FromHtml("#730039");

	public static Color NightBlue => ColorTranslator.FromHtml("#040348");

	public static Color PurpleishPink => ColorTranslator.FromHtml("#df4ec8");

	public static Color Apple => ColorTranslator.FromHtml("#6ecb3c");

	public static Color BabyPoopGreen => ColorTranslator.FromHtml("#8f9805");

	public static Color GreenApple => ColorTranslator.FromHtml("#5edc1f");

	public static Color Heliotrope => ColorTranslator.FromHtml("#d94ff5");

	public static Color Yellow_Green => ColorTranslator.FromHtml("#c8fd3d");

	public static Color AlmostBlack => ColorTranslator.FromHtml("#070d0d");

	public static Color CoolBlue => ColorTranslator.FromHtml("#4984b8");

	public static Color LeafyGreen => ColorTranslator.FromHtml("#51b73b");

	public static Color MustardBrown => ColorTranslator.FromHtml("#ac7e04");

	public static Color Dusk => ColorTranslator.FromHtml("#4e5481");

	public static Color DullBrown => ColorTranslator.FromHtml("#876e4b");

	public static Color FrogGreen => ColorTranslator.FromHtml("#58bc08");

	public static Color VividGreen => ColorTranslator.FromHtml("#2fef10");

	public static Color BrightLightGreen => ColorTranslator.FromHtml("#2dfe54");

	public static Color FluroGreen => ColorTranslator.FromHtml("#0aff02");

	public static Color Kiwi => ColorTranslator.FromHtml("#9cef43");

	public static Color Seaweed => ColorTranslator.FromHtml("#18d17b");

	public static Color NavyGreen => ColorTranslator.FromHtml("#35530a");

	public static Color UltramarineBlue => ColorTranslator.FromHtml("#1805db");

	public static Color Iris => ColorTranslator.FromHtml("#6258c4");

	public static Color PastelOrange => ColorTranslator.FromHtml("#ff964f");

	public static Color YellowishOrange => ColorTranslator.FromHtml("#ffab0f");

	public static Color Perrywinkle => ColorTranslator.FromHtml("#8f8ce7");

	public static Color Tealish => ColorTranslator.FromHtml("#24bca8");

	public static Color DarkPlum => ColorTranslator.FromHtml("#3f012c");

	public static Color Pear => ColorTranslator.FromHtml("#cbf85f");

	public static Color PinkishOrange => ColorTranslator.FromHtml("#ff724c");

	public static Color MidnightPurple => ColorTranslator.FromHtml("#280137");

	public static Color LightUrple => ColorTranslator.FromHtml("#b36ff6");

	public static Color DarkMint => ColorTranslator.FromHtml("#48c072");

	public static Color GreenishTan => ColorTranslator.FromHtml("#bccb7a");

	public static Color LightBurgundy => ColorTranslator.FromHtml("#a8415b");

	public static Color TurquoiseBlue => ColorTranslator.FromHtml("#06b1c4");

	public static Color UglyPink => ColorTranslator.FromHtml("#cd7584");

	public static Color Sandy => ColorTranslator.FromHtml("#f1da7a");

	public static Color ElectricPink => ColorTranslator.FromHtml("#ff0490");

	public static Color MutedPurple => ColorTranslator.FromHtml("#805b87");

	public static Color MidGreen => ColorTranslator.FromHtml("#50a747");

	public static Color Greyish => ColorTranslator.FromHtml("#a8a495");

	public static Color NeonYellow => ColorTranslator.FromHtml("#cfff04");

	public static Color Banana => ColorTranslator.FromHtml("#ffff7e");

	public static Color CarnationPink => ColorTranslator.FromHtml("#ff7fa7");

	public static Color Tomato => ColorTranslator.FromHtml("#ef4026");

	public static Color Sea => ColorTranslator.FromHtml("#3c9992");

	public static Color MuddyBrown => ColorTranslator.FromHtml("#886806");

	public static Color TurquoiseGreen => ColorTranslator.FromHtml("#04f489");

	public static Color Buff => ColorTranslator.FromHtml("#fef69e");

	public static Color Fawn => ColorTranslator.FromHtml("#cfaf7b");

	public static Color MutedBlue => ColorTranslator.FromHtml("#3b719f");

	public static Color PaleRose => ColorTranslator.FromHtml("#fdc1c5");

	public static Color DarkMintGreen => ColorTranslator.FromHtml("#20c073");

	public static Color Amethyst => ColorTranslator.FromHtml("#9b5fc0");

	public static Color Blue_Green => ColorTranslator.FromHtml("#0f9b8e");

	public static Color Chestnut => ColorTranslator.FromHtml("#742802");

	public static Color SickGreen => ColorTranslator.FromHtml("#9db92c");

	public static Color Pea => ColorTranslator.FromHtml("#a4bf20");

	public static Color RustyOrange => ColorTranslator.FromHtml("#cd5909");

	public static Color Stone => ColorTranslator.FromHtml("#ada587");

	public static Color RoseRed => ColorTranslator.FromHtml("#be013c");

	public static Color PaleAqua => ColorTranslator.FromHtml("#b8ffeb");

	public static Color DeepOrange => ColorTranslator.FromHtml("#dc4d01");

	public static Color Earth => ColorTranslator.FromHtml("#a2653e");

	public static Color MossyGreen => ColorTranslator.FromHtml("#638b27");

	public static Color GrassyGreen => ColorTranslator.FromHtml("#419c03");

	public static Color PaleLimeGreen => ColorTranslator.FromHtml("#b1ff65");

	public static Color LightGreyBlue => ColorTranslator.FromHtml("#9dbcd4");

	public static Color PaleGrey => ColorTranslator.FromHtml("#fdfdfe");

	public static Color Asparagus => ColorTranslator.FromHtml("#77ab56");

	public static Color Blueberry => ColorTranslator.FromHtml("#464196");

	public static Color PurpleRed => ColorTranslator.FromHtml("#990147");

	public static Color PaleLime => ColorTranslator.FromHtml("#befd73");

	public static Color GreenishTeal => ColorTranslator.FromHtml("#32bf84");

	public static Color Caramel => ColorTranslator.FromHtml("#af6f09");

	public static Color DeepMagenta => ColorTranslator.FromHtml("#a0025c");

	public static Color LightPeach => ColorTranslator.FromHtml("#ffd8b1");

	public static Color MilkChocolate => ColorTranslator.FromHtml("#7f4e1e");

	public static Color Ocher => ColorTranslator.FromHtml("#bf9b0c");

	public static Color OffGreen => ColorTranslator.FromHtml("#6ba353");

	public static Color PurplyPink => ColorTranslator.FromHtml("#f075e6");

	public static Color Lightblue => ColorTranslator.FromHtml("#7bc8f6");

	public static Color DuskyBlue => ColorTranslator.FromHtml("#475f94");

	public static Color Golden => ColorTranslator.FromHtml("#f5bf03");

	public static Color LightBeige => ColorTranslator.FromHtml("#fffeb6");

	public static Color ButterYellow => ColorTranslator.FromHtml("#fffd74");

	public static Color DuskyPurple => ColorTranslator.FromHtml("#895b7b");

	public static Color FrenchBlue => ColorTranslator.FromHtml("#436bad");

	public static Color UglyYellow => ColorTranslator.FromHtml("#d0c101");

	public static Color GreenyYellow => ColorTranslator.FromHtml("#c6f808");

	public static Color OrangishRed => ColorTranslator.FromHtml("#f43605");

	public static Color ShamrockGreen => ColorTranslator.FromHtml("#02c14d");

	public static Color OrangishBrown => ColorTranslator.FromHtml("#b25f03");

	public static Color TreeGreen => ColorTranslator.FromHtml("#2a7e19");

	public static Color DeepViolet => ColorTranslator.FromHtml("#490648");

	public static Color Gunmetal => ColorTranslator.FromHtml("#536267");

	public static Color Blue_Purple => ColorTranslator.FromHtml("#5a06ef");

	public static Color Cherry => ColorTranslator.FromHtml("#cf0234");

	public static Color SandyBrown => ColorTranslator.FromHtml("#c4a661");

	public static Color WarmGrey => ColorTranslator.FromHtml("#978a84");

	public static Color DarkIndigo => ColorTranslator.FromHtml("#1f0954");

	public static Color Midnight => ColorTranslator.FromHtml("#03012d");

	public static Color BlueyGreen => ColorTranslator.FromHtml("#2bb179");

	public static Color GreyPink => ColorTranslator.FromHtml("#c3909b");

	public static Color SoftPurple => ColorTranslator.FromHtml("#a66fb5");

	public static Color Blood => ColorTranslator.FromHtml("#770001");

	public static Color BrownRed => ColorTranslator.FromHtml("#922b05");

	public static Color MediumGrey => ColorTranslator.FromHtml("#7d7f7c");

	public static Color Berry => ColorTranslator.FromHtml("#990f4b");

	public static Color Poo => ColorTranslator.FromHtml("#8f7303");

	public static Color PurpleyPink => ColorTranslator.FromHtml("#c83cb9");

	public static Color LightSalmon => ColorTranslator.FromHtml("#fea993");

	public static Color Snot => ColorTranslator.FromHtml("#acbb0d");

	public static Color EasterPurple => ColorTranslator.FromHtml("#c071fe");

	public static Color LightYellowGreen => ColorTranslator.FromHtml("#ccfd7f");

	public static Color DarkNavyBlue => ColorTranslator.FromHtml("#00022e");

	public static Color Drab => ColorTranslator.FromHtml("#828344");

	public static Color LightRose => ColorTranslator.FromHtml("#ffc5cb");

	public static Color Rouge => ColorTranslator.FromHtml("#ab1239");

	public static Color PurplishRed => ColorTranslator.FromHtml("#b0054b");

	public static Color SlimeGreen => ColorTranslator.FromHtml("#99cc04");

	public static Color BabyPoop => ColorTranslator.FromHtml("#937c00");

	public static Color IrishGreen => ColorTranslator.FromHtml("#019529");

	public static Color Pink_Purple => ColorTranslator.FromHtml("#ef1de7");

	public static Color DarkNavy => ColorTranslator.FromHtml("#000435");

	public static Color GreenyBlue => ColorTranslator.FromHtml("#42b395");

	public static Color LightPlum => ColorTranslator.FromHtml("#9d5783");

	public static Color PinkishGrey => ColorTranslator.FromHtml("#c8aca9");

	public static Color DirtyOrange => ColorTranslator.FromHtml("#c87606");

	public static Color RustRed => ColorTranslator.FromHtml("#aa2704");

	public static Color PaleLilac => ColorTranslator.FromHtml("#e4cbff");

	public static Color OrangeyRed => ColorTranslator.FromHtml("#fa4224");

	public static Color PrimaryBlue => ColorTranslator.FromHtml("#0804f9");

	public static Color KermitGreen => ColorTranslator.FromHtml("#5cb200");

	public static Color BrownishPurple => ColorTranslator.FromHtml("#76424e");

	public static Color MurkyGreen => ColorTranslator.FromHtml("#6c7a0e");

	public static Color Wheat => ColorTranslator.FromHtml("#fbdd7e");

	public static Color VeryDarkPurple => ColorTranslator.FromHtml("#2a0134");

	public static Color BottleGreen => ColorTranslator.FromHtml("#044a05");

	public static Color Watermelon => ColorTranslator.FromHtml("#fd4659");

	public static Color DeepSkyBlue => ColorTranslator.FromHtml("#0d75f8");

	public static Color FireEngineRed => ColorTranslator.FromHtml("#fe0002");

	public static Color YellowOchre => ColorTranslator.FromHtml("#cb9d06");

	public static Color PumpkinOrange => ColorTranslator.FromHtml("#fb7d07");

	public static Color PaleOlive => ColorTranslator.FromHtml("#b9cc81");

	public static Color LightLilac => ColorTranslator.FromHtml("#edc8ff");

	public static Color LightishGreen => ColorTranslator.FromHtml("#61e160");

	public static Color CarolinaBlue => ColorTranslator.FromHtml("#8ab8fe");

	public static Color Mulberry => ColorTranslator.FromHtml("#920a4e");

	public static Color ShockingPink => ColorTranslator.FromHtml("#fe02a2");

	public static Color Auburn => ColorTranslator.FromHtml("#9a3001");

	public static Color BrightLimeGreen => ColorTranslator.FromHtml("#65fe08");

	public static Color Celadon => ColorTranslator.FromHtml("#befdb7");

	public static Color PinkishBrown => ColorTranslator.FromHtml("#b17261");

	public static Color PooBrown => ColorTranslator.FromHtml("#885f01");

	public static Color BrightSkyBlue => ColorTranslator.FromHtml("#02ccfe");

	public static Color Celery => ColorTranslator.FromHtml("#c1fd95");

	public static Color DirtBrown => ColorTranslator.FromHtml("#836539");

	public static Color Strawberry => ColorTranslator.FromHtml("#fb2943");

	public static Color DarkLime => ColorTranslator.FromHtml("#84b701");

	public static Color Copper => ColorTranslator.FromHtml("#b66325");

	public static Color MediumBrown => ColorTranslator.FromHtml("#7f5112");

	public static Color MutedGreen => ColorTranslator.FromHtml("#5fa052");

	public static Color RobinSEgg => ColorTranslator.FromHtml("#6dedfd");

	public static Color BrightAqua => ColorTranslator.FromHtml("#0bf9ea");

	public static Color BrightLavender => ColorTranslator.FromHtml("#c760ff");

	public static Color Ivory => ColorTranslator.FromHtml("#ffffcb");

	public static Color VeryLightPurple => ColorTranslator.FromHtml("#f6cefc");

	public static Color LightNavy => ColorTranslator.FromHtml("#155084");

	public static Color PinkRed => ColorTranslator.FromHtml("#f5054f");

	public static Color OliveBrown => ColorTranslator.FromHtml("#645403");

	public static Color PoopBrown => ColorTranslator.FromHtml("#7a5901");

	public static Color MustardGreen => ColorTranslator.FromHtml("#a8b504");

	public static Color OceanGreen => ColorTranslator.FromHtml("#3d9973");

	public static Color VeryDarkBlue => ColorTranslator.FromHtml("#000133");

	public static Color DustyGreen => ColorTranslator.FromHtml("#76a973");

	public static Color LightNavyBlue => ColorTranslator.FromHtml("#2e5a88");

	public static Color MintyGreen => ColorTranslator.FromHtml("#0bf77d");

	public static Color Adobe => ColorTranslator.FromHtml("#bd6c48");

	public static Color Barney => ColorTranslator.FromHtml("#ac1db8");

	public static Color JadeGreen => ColorTranslator.FromHtml("#2baf6a");

	public static Color BrightLightBlue => ColorTranslator.FromHtml("#26f7fd");

	public static Color LightLime => ColorTranslator.FromHtml("#aefd6c");

	public static Color DarkKhaki => ColorTranslator.FromHtml("#9b8f55");

	public static Color OrangeYellow => ColorTranslator.FromHtml("#ffad01");

	public static Color Ocre => ColorTranslator.FromHtml("#c69c04");

	public static Color Maize => ColorTranslator.FromHtml("#f4d054");

	public static Color FadedPink => ColorTranslator.FromHtml("#de9dac");

	public static Color BritishRacingGreen => ColorTranslator.FromHtml("#05480d");

	public static Color Sandstone => ColorTranslator.FromHtml("#c9ae74");

	public static Color MudBrown => ColorTranslator.FromHtml("#60460f");

	public static Color LightSeaGreen => ColorTranslator.FromHtml("#98f6b0");

	public static Color RobinEggBlue => ColorTranslator.FromHtml("#8af1fe");

	public static Color AquaMarine => ColorTranslator.FromHtml("#2ee8bb");

	public static Color DarkSeaGreen => ColorTranslator.FromHtml("#11875d");

	public static Color SoftPink => ColorTranslator.FromHtml("#fdb0c0");

	public static Color OrangeyBrown => ColorTranslator.FromHtml("#b16002");

	public static Color CherryRed => ColorTranslator.FromHtml("#f7022a");

	public static Color BurntYellow => ColorTranslator.FromHtml("#d5ab09");

	public static Color BrownishGrey => ColorTranslator.FromHtml("#86775f");

	public static Color Camel => ColorTranslator.FromHtml("#c69f59");

	public static Color PurplishGrey => ColorTranslator.FromHtml("#7a687f");

	public static Color Marine => ColorTranslator.FromHtml("#042e60");

	public static Color GreyishPink => ColorTranslator.FromHtml("#c88d94");

	public static Color PaleTurquoise => ColorTranslator.FromHtml("#a5fbd5");

	public static Color PastelYellow => ColorTranslator.FromHtml("#fffe71");

	public static Color BlueyPurple => ColorTranslator.FromHtml("#6241c7");

	public static Color CanaryYellow => ColorTranslator.FromHtml("#fffe40");

	public static Color FadedRed => ColorTranslator.FromHtml("#d3494e");

	public static Color Sepia => ColorTranslator.FromHtml("#985e2b");

	public static Color Coffee => ColorTranslator.FromHtml("#a6814c");

	public static Color BrightMagenta => ColorTranslator.FromHtml("#ff08e8");

	public static Color Mocha => ColorTranslator.FromHtml("#9d7651");

	public static Color Ecru => ColorTranslator.FromHtml("#feffca");

	public static Color Purpleish => ColorTranslator.FromHtml("#98568d");

	public static Color Cranberry => ColorTranslator.FromHtml("#9e003a");

	public static Color DarkishGreen => ColorTranslator.FromHtml("#287c37");

	public static Color BrownOrange => ColorTranslator.FromHtml("#b96902");

	public static Color DuskyRose => ColorTranslator.FromHtml("#ba6873");

	public static Color Melon => ColorTranslator.FromHtml("#ff7855");

	public static Color SicklyGreen => ColorTranslator.FromHtml("#94b21c");

	public static Color Silver => ColorTranslator.FromHtml("#c5c9c7");

	public static Color PurplyBlue => ColorTranslator.FromHtml("#661aee");

	public static Color PurpleishBlue => ColorTranslator.FromHtml("#6140ef");

	public static Color HospitalGreen => ColorTranslator.FromHtml("#9be5aa");

	public static Color ShitBrown => ColorTranslator.FromHtml("#7b5804");

	public static Color MidBlue => ColorTranslator.FromHtml("#276ab3");

	public static Color Amber => ColorTranslator.FromHtml("#feb308");

	public static Color EasterGreen => ColorTranslator.FromHtml("#8cfd7e");

	public static Color SoftBlue => ColorTranslator.FromHtml("#6488ea");

	public static Color CeruleanBlue => ColorTranslator.FromHtml("#056eee");

	public static Color GoldenBrown => ColorTranslator.FromHtml("#b27a01");

	public static Color BrightTurquoise => ColorTranslator.FromHtml("#0ffef9");

	public static Color RedPink => ColorTranslator.FromHtml("#fa2a55");

	public static Color RedPurple => ColorTranslator.FromHtml("#820747");

	public static Color GreyishBrown => ColorTranslator.FromHtml("#7a6a4f");

	public static Color Vermillion => ColorTranslator.FromHtml("#f4320c");

	public static Color Russet => ColorTranslator.FromHtml("#a13905");

	public static Color SteelGrey => ColorTranslator.FromHtml("#6f828a");

	public static Color LighterPurple => ColorTranslator.FromHtml("#a55af4");

	public static Color BrightViolet => ColorTranslator.FromHtml("#ad0afd");

	public static Color PrussianBlue => ColorTranslator.FromHtml("#004577");

	public static Color SlateGreen => ColorTranslator.FromHtml("#658d6d");

	public static Color DirtyPink => ColorTranslator.FromHtml("#ca7b80");

	public static Color DarkBlueGreen => ColorTranslator.FromHtml("#005249");

	public static Color Pine => ColorTranslator.FromHtml("#2b5d34");

	public static Color YellowyGreen => ColorTranslator.FromHtml("#bff128");

	public static Color DarkGold => ColorTranslator.FromHtml("#b59410");

	public static Color Bluish => ColorTranslator.FromHtml("#2976bb");

	public static Color DarkishBlue => ColorTranslator.FromHtml("#014182");

	public static Color DullRed => ColorTranslator.FromHtml("#bb3f3f");

	public static Color PinkyRed => ColorTranslator.FromHtml("#fc2647");

	public static Color Bronze => ColorTranslator.FromHtml("#a87900");

	public static Color PaleTeal => ColorTranslator.FromHtml("#82cbb2");

	public static Color MilitaryGreen => ColorTranslator.FromHtml("#667c3e");

	public static Color BarbiePink => ColorTranslator.FromHtml("#fe46a5");

	public static Color BubblegumPink => ColorTranslator.FromHtml("#fe83cc");

	public static Color PeaSoupGreen => ColorTranslator.FromHtml("#94a617");

	public static Color DarkMustard => ColorTranslator.FromHtml("#a88905");

	public static Color Shit => ColorTranslator.FromHtml("#7f5f00");

	public static Color MediumPurple => ColorTranslator.FromHtml("#9e43a2");

	public static Color VeryDarkGreen => ColorTranslator.FromHtml("#062e03");

	public static Color Dirt => ColorTranslator.FromHtml("#8a6e45");

	public static Color DuskyPink => ColorTranslator.FromHtml("#cc7a8b");

	public static Color RedViolet => ColorTranslator.FromHtml("#9e0168");

	public static Color LemonYellow => ColorTranslator.FromHtml("#fdff38");

	public static Color Pistachio => ColorTranslator.FromHtml("#c0fa8b");

	public static Color DullYellow => ColorTranslator.FromHtml("#eedc5b");

	public static Color DarkLimeGreen => ColorTranslator.FromHtml("#7ebd01");

	public static Color DenimBlue => ColorTranslator.FromHtml("#3b5b92");

	public static Color TealBlue => ColorTranslator.FromHtml("#01889f");

	public static Color LightishBlue => ColorTranslator.FromHtml("#3d7afd");

	public static Color PurpleyBlue => ColorTranslator.FromHtml("#5f34e7");

	public static Color LightIndigo => ColorTranslator.FromHtml("#6d5acf");

	public static Color SwampGreen => ColorTranslator.FromHtml("#748500");

	public static Color BrownGreen => ColorTranslator.FromHtml("#706c11");

	public static Color DarkMaroon => ColorTranslator.FromHtml("#3c0008");

	public static Color HotPurple => ColorTranslator.FromHtml("#cb00f5");

	public static Color DarkForestGreen => ColorTranslator.FromHtml("#002d04");

	public static Color FadedBlue => ColorTranslator.FromHtml("#658cbb");

	public static Color DrabGreen => ColorTranslator.FromHtml("#749551");

	public static Color LightLimeGreen => ColorTranslator.FromHtml("#b9ff66");

	public static Color SnotGreen => ColorTranslator.FromHtml("#9dc100");

	public static Color Yellowish => ColorTranslator.FromHtml("#faee66");

	public static Color LightBlueGreen => ColorTranslator.FromHtml("#7efbb3");

	public static Color Bordeaux => ColorTranslator.FromHtml("#7b002c");

	public static Color LightMauve => ColorTranslator.FromHtml("#c292a1");

	public static Color Ocean => ColorTranslator.FromHtml("#017b92");

	public static Color Marigold => ColorTranslator.FromHtml("#fcc006");

	public static Color MuddyGreen => ColorTranslator.FromHtml("#657432");

	public static Color DullOrange => ColorTranslator.FromHtml("#d8863b");

	public static Color Steel => ColorTranslator.FromHtml("#738595");

	public static Color ElectricPurple => ColorTranslator.FromHtml("#aa23ff");

	public static Color FluorescentGreen => ColorTranslator.FromHtml("#08ff08");

	public static Color YellowishBrown => ColorTranslator.FromHtml("#9b7a01");

	public static Color Blush => ColorTranslator.FromHtml("#f29e8e");

	public static Color SoftGreen => ColorTranslator.FromHtml("#6fc276");

	public static Color BrightOrange => ColorTranslator.FromHtml("#ff5b00");

	public static Color Lemon => ColorTranslator.FromHtml("#fdff52");

	public static Color PurpleGrey => ColorTranslator.FromHtml("#866f85");

	public static Color AcidGreen => ColorTranslator.FromHtml("#8ffe09");

	public static Color PaleLavender => ColorTranslator.FromHtml("#eecffe");

	public static Color VioletBlue => ColorTranslator.FromHtml("#510ac9");

	public static Color LightForestGreen => ColorTranslator.FromHtml("#4f9153");

	public static Color BurntRed => ColorTranslator.FromHtml("#9f2305");

	public static Color KhakiGreen => ColorTranslator.FromHtml("#728639");

	public static Color Cerise => ColorTranslator.FromHtml("#de0c62");

	public static Color FadedPurple => ColorTranslator.FromHtml("#916e99");

	public static Color Apricot => ColorTranslator.FromHtml("#ffb16d");

	public static Color DarkOliveGreen => ColorTranslator.FromHtml("#3c4d03");

	public static Color GreyBrown => ColorTranslator.FromHtml("#7f7053");

	public static Color GreenGrey => ColorTranslator.FromHtml("#77926f");

	public static Color TrueBlue => ColorTranslator.FromHtml("#010fcc");

	public static Color PaleViolet => ColorTranslator.FromHtml("#ceaefa");

	public static Color PeriwinkleBlue => ColorTranslator.FromHtml("#8f99fb");

	public static Color LightSkyBlue => ColorTranslator.FromHtml("#c6fcff");

	public static Color Blurple => ColorTranslator.FromHtml("#5539cc");

	public static Color GreenBrown => ColorTranslator.FromHtml("#544e03");

	public static Color Bluegreen => ColorTranslator.FromHtml("#017a79");

	public static Color BrightTeal => ColorTranslator.FromHtml("#01f9c6");

	public static Color BrownishYellow => ColorTranslator.FromHtml("#c9b003");

	public static Color PeaSoup => ColorTranslator.FromHtml("#929901");

	public static Color Forest => ColorTranslator.FromHtml("#0b5509");

	public static Color BarneyPurple => ColorTranslator.FromHtml("#a00498");

	public static Color Ultramarine => ColorTranslator.FromHtml("#2000b1");

	public static Color Purplish => ColorTranslator.FromHtml("#94568c");

	public static Color PukeYellow => ColorTranslator.FromHtml("#c2be0e");

	public static Color BluishGrey => ColorTranslator.FromHtml("#748b97");

	public static Color DarkPeriwinkle => ColorTranslator.FromHtml("#665fd1");

	public static Color DarkLilac => ColorTranslator.FromHtml("#9c6da5");

	public static Color Reddish => ColorTranslator.FromHtml("#c44240");

	public static Color LightMaroon => ColorTranslator.FromHtml("#a24857");

	public static Color DustyPurple => ColorTranslator.FromHtml("#825f87");

	public static Color TerraCotta => ColorTranslator.FromHtml("#c9643b");

	public static Color Avocado => ColorTranslator.FromHtml("#90b134");

	public static Color MarineBlue => ColorTranslator.FromHtml("#01386a");

	public static Color TealGreen => ColorTranslator.FromHtml("#25a36f");

	public static Color SlateGrey => ColorTranslator.FromHtml("#59656d");

	public static Color LighterGreen => ColorTranslator.FromHtml("#75fd63");

	public static Color ElectricGreen => ColorTranslator.FromHtml("#21fc0d");

	public static Color DustyBlue => ColorTranslator.FromHtml("#5a86ad");

	public static Color GoldenYellow => ColorTranslator.FromHtml("#fec615");

	public static Color BrightYellow => ColorTranslator.FromHtml("#fffd01");

	public static Color LightLavender => ColorTranslator.FromHtml("#dfc5fe");

	public static Color Umber => ColorTranslator.FromHtml("#b26400");

	public static Color Poop => ColorTranslator.FromHtml("#7f5e00");

	public static Color DarkPeach => ColorTranslator.FromHtml("#de7e5d");

	public static Color JungleGreen => ColorTranslator.FromHtml("#048243");

	public static Color Eggshell => ColorTranslator.FromHtml("#ffffd4");

	public static Color Denim => ColorTranslator.FromHtml("#3b638c");

	public static Color YellowBrown => ColorTranslator.FromHtml("#b79400");

	public static Color DullPurple => ColorTranslator.FromHtml("#84597e");

	public static Color ChocolateBrown => ColorTranslator.FromHtml("#411900");

	public static Color WineRed => ColorTranslator.FromHtml("#7b0323");

	public static Color NeonBlue => ColorTranslator.FromHtml("#04d9ff");

	public static Color DirtyGreen => ColorTranslator.FromHtml("#667e2c");

	public static Color LightTan => ColorTranslator.FromHtml("#fbeeac");

	public static Color IceBlue => ColorTranslator.FromHtml("#d7fffe");

	public static Color CadetBlue => ColorTranslator.FromHtml("#4e7496");

	public static Color DarkMauve => ColorTranslator.FromHtml("#874c62");

	public static Color VeryLightBlue => ColorTranslator.FromHtml("#d5ffff");

	public static Color GreyPurple => ColorTranslator.FromHtml("#826d8c");

	public static Color PastelPink => ColorTranslator.FromHtml("#ffbacd");

	public static Color VeryLightGreen => ColorTranslator.FromHtml("#d1ffbd");

	public static Color DarkSkyBlue => ColorTranslator.FromHtml("#448ee4");

	public static Color Evergreen => ColorTranslator.FromHtml("#05472a");

	public static Color DullPink => ColorTranslator.FromHtml("#d5869d");

	public static Color Aubergine => ColorTranslator.FromHtml("#3d0734");

	public static Color Mahogany => ColorTranslator.FromHtml("#4a0100");

	public static Color ReddishOrange => ColorTranslator.FromHtml("#f8481c");

	public static Color DeepGreen => ColorTranslator.FromHtml("#02590f");

	public static Color VomitGreen => ColorTranslator.FromHtml("#89a203");

	public static Color PurplePink => ColorTranslator.FromHtml("#e03fd8");

	public static Color DustyPink => ColorTranslator.FromHtml("#d58a94");

	public static Color FadedGreen => ColorTranslator.FromHtml("#7bb274");

	public static Color CamoGreen => ColorTranslator.FromHtml("#526525");

	public static Color PinkyPurple => ColorTranslator.FromHtml("#c94cbe");

	public static Color PinkPurple => ColorTranslator.FromHtml("#db4bda");

	public static Color BrownishRed => ColorTranslator.FromHtml("#9e3623");

	public static Color DarkRose => ColorTranslator.FromHtml("#b5485d");

	public static Color Mud => ColorTranslator.FromHtml("#735c12");

	public static Color Brownish => ColorTranslator.FromHtml("#9c6d57");

	public static Color EmeraldGreen => ColorTranslator.FromHtml("#028f1e");

	public static Color PaleBrown => ColorTranslator.FromHtml("#b1916e");

	public static Color DullBlue => ColorTranslator.FromHtml("#49759c");

	public static Color BurntUmber => ColorTranslator.FromHtml("#a0450e");

	public static Color MediumGreen => ColorTranslator.FromHtml("#39ad48");

	public static Color Clay => ColorTranslator.FromHtml("#b66a50");

	public static Color LightAqua => ColorTranslator.FromHtml("#8cffdb");

	public static Color LightOliveGreen => ColorTranslator.FromHtml("#a4be5c");

	public static Color BrownishOrange => ColorTranslator.FromHtml("#cb7723");

	public static Color DarkAqua => ColorTranslator.FromHtml("#05696b");

	public static Color PurplishPink => ColorTranslator.FromHtml("#ce5dae");

	public static Color DarkSalmon => ColorTranslator.FromHtml("#c85a53");

	public static Color GreenishGrey => ColorTranslator.FromHtml("#96ae8d");

	public static Color Jade => ColorTranslator.FromHtml("#1fa774");

	public static Color UglyGreen => ColorTranslator.FromHtml("#7a9703");

	public static Color DarkBeige => ColorTranslator.FromHtml("#ac9362");

	public static Color Emerald => ColorTranslator.FromHtml("#01a049");

	public static Color PaleRed => ColorTranslator.FromHtml("#d9544d");

	public static Color LightMagenta => ColorTranslator.FromHtml("#fa5ff7");

	public static Color Sky => ColorTranslator.FromHtml("#82cafc");

	public static Color LightCyan => ColorTranslator.FromHtml("#acfffc");

	public static Color YellowOrange => ColorTranslator.FromHtml("#fcb001");

	public static Color ReddishPurple => ColorTranslator.FromHtml("#910951");

	public static Color ReddishPink => ColorTranslator.FromHtml("#fe2c54");

	public static Color Orchid => ColorTranslator.FromHtml("#c875c4");

	public static Color DirtyYellow => ColorTranslator.FromHtml("#cdc50a");

	public static Color OrangeRed => ColorTranslator.FromHtml("#fd411e");

	public static Color DeepRed => ColorTranslator.FromHtml("#9a0200");

	public static Color OrangeBrown => ColorTranslator.FromHtml("#be6400");

	public static Color CobaltBlue => ColorTranslator.FromHtml("#030aa7");

	public static Color NeonPink => ColorTranslator.FromHtml("#fe019a");

	public static Color RosePink => ColorTranslator.FromHtml("#f7879a");

	public static Color GreyishPurple => ColorTranslator.FromHtml("#887191");

	public static Color Raspberry => ColorTranslator.FromHtml("#b00149");

	public static Color AquaGreen => ColorTranslator.FromHtml("#12e193");

	public static Color SalmonPink => ColorTranslator.FromHtml("#fe7b7c");

	public static Color Tangerine => ColorTranslator.FromHtml("#ff9408");

	public static Color BrownishGreen => ColorTranslator.FromHtml("#6a6e09");

	public static Color RedBrown => ColorTranslator.FromHtml("#8b2e16");

	public static Color GreenishBrown => ColorTranslator.FromHtml("#696112");

	public static Color Pumpkin => ColorTranslator.FromHtml("#e17701");

	public static Color PineGreen => ColorTranslator.FromHtml("#0a481e");

	public static Color Charcoal => ColorTranslator.FromHtml("#343837");

	public static Color BabyPink => ColorTranslator.FromHtml("#ffb7ce");

	public static Color Cornflower => ColorTranslator.FromHtml("#6a79f7");

	public static Color BlueViolet => ColorTranslator.FromHtml("#5d06e9");

	public static Color Chocolate => ColorTranslator.FromHtml("#3d1c02");

	public static Color GreyishGreen => ColorTranslator.FromHtml("#82a67d");

	public static Color Scarlet => ColorTranslator.FromHtml("#be0119");

	public static Color GreenYellow => ColorTranslator.FromHtml("#c9ff27");

	public static Color DarkOlive => ColorTranslator.FromHtml("#373e02");

	public static Color Sienna => ColorTranslator.FromHtml("#a9561e");

	public static Color PastelPurple => ColorTranslator.FromHtml("#caa0ff");

	public static Color Terracotta => ColorTranslator.FromHtml("#ca6641");

	public static Color AquaBlue => ColorTranslator.FromHtml("#02d8e9");

	public static Color SageGreen => ColorTranslator.FromHtml("#88b378");

	public static Color BloodRed => ColorTranslator.FromHtml("#980002");

	public static Color DeepPink => ColorTranslator.FromHtml("#cb0162");

	public static Color Grass => ColorTranslator.FromHtml("#5cac2d");

	public static Color Moss => ColorTranslator.FromHtml("#769958");

	public static Color PastelBlue => ColorTranslator.FromHtml("#a2bffe");

	public static Color BluishGreen => ColorTranslator.FromHtml("#10a674");

	public static Color GreenBlue => ColorTranslator.FromHtml("#06b48b");

	public static Color DarkTan => ColorTranslator.FromHtml("#af884a");

	public static Color GreenishBlue => ColorTranslator.FromHtml("#0b8b87");

	public static Color PaleOrange => ColorTranslator.FromHtml("#ffa756");

	public static Color Vomit => ColorTranslator.FromHtml("#a2a415");

	public static Color ForrestGreen => ColorTranslator.FromHtml("#154406");

	public static Color DarkLavender => ColorTranslator.FromHtml("#856798");

	public static Color DarkViolet => ColorTranslator.FromHtml("#34013f");

	public static Color PurpleBlue => ColorTranslator.FromHtml("#632de9");

	public static Color DarkCyan => ColorTranslator.FromHtml("#0a888a");

	public static Color OliveDrab => ColorTranslator.FromHtml("#6f7632");

	public static Color Pinkish => ColorTranslator.FromHtml("#d46a7e");

	public static Color Cobalt => ColorTranslator.FromHtml("#1e488f");

	public static Color NeonPurple => ColorTranslator.FromHtml("#bc13fe");

	public static Color LightTurquoise => ColorTranslator.FromHtml("#7ef4cc");

	public static Color AppleGreen => ColorTranslator.FromHtml("#76cd26");

	public static Color DullGreen => ColorTranslator.FromHtml("#74a662");

	public static Color Wine => ColorTranslator.FromHtml("#80013f");

	public static Color PowderBlue => ColorTranslator.FromHtml("#b1d1fc");

	public static Color OffWhite => ColorTranslator.FromHtml("#ffffe4");

	public static Color ElectricBlue => ColorTranslator.FromHtml("#0652ff");

	public static Color DarkTurquoise => ColorTranslator.FromHtml("#045c5a");

	public static Color BluePurple => ColorTranslator.FromHtml("#5729ce");

	public static Color Azure => ColorTranslator.FromHtml("#069af3");

	public static Color BrightRed => ColorTranslator.FromHtml("#ff000d");

	public static Color PinkishRed => ColorTranslator.FromHtml("#f10c45");

	public static Color CornflowerBlue => ColorTranslator.FromHtml("#5170d7");

	public static Color LightOlive => ColorTranslator.FromHtml("#acbf69");

	public static Color Grape => ColorTranslator.FromHtml("#6c3461");

	public static Color GreyishBlue => ColorTranslator.FromHtml("#5e819d");

	public static Color PurplishBlue => ColorTranslator.FromHtml("#601ef9");

	public static Color YellowishGreen => ColorTranslator.FromHtml("#b0dd16");

	public static Color GreenishYellow => ColorTranslator.FromHtml("#cdfd02");

	public static Color MediumBlue => ColorTranslator.FromHtml("#2c6fbb");

	public static Color DustyRose => ColorTranslator.FromHtml("#c0737a");

	public static Color LightViolet => ColorTranslator.FromHtml("#d6b4fc");

	public static Color MidnightBlue => ColorTranslator.FromHtml("#020035");

	public static Color BluishPurple => ColorTranslator.FromHtml("#703be7");

	public static Color RedOrange => ColorTranslator.FromHtml("#fd3c06");

	public static Color DarkMagenta => ColorTranslator.FromHtml("#960056");

	public static Color Greenish => ColorTranslator.FromHtml("#40a368");

	public static Color OceanBlue => ColorTranslator.FromHtml("#03719c");

	public static Color Coral => ColorTranslator.FromHtml("#fc5a50");

	public static Color Cream => ColorTranslator.FromHtml("#ffffc2");

	public static Color ReddishBrown => ColorTranslator.FromHtml("#7f2b0a");

	public static Color BurntSienna => ColorTranslator.FromHtml("#b04e0f");

	public static Color Brick => ColorTranslator.FromHtml("#a03623");

	public static Color Sage => ColorTranslator.FromHtml("#87ae73");

	public static Color GreyGreen => ColorTranslator.FromHtml("#789b73");

	public static Color White => ColorTranslator.FromHtml("#ffffff");

	public static Color RobinSEggBlue => ColorTranslator.FromHtml("#98eff9");

	public static Color MossGreen => ColorTranslator.FromHtml("#658b38");

	public static Color SteelBlue => ColorTranslator.FromHtml("#5a7d9a");

	public static Color Eggplant => ColorTranslator.FromHtml("#380835");

	public static Color LightYellow => ColorTranslator.FromHtml("#fffe7a");

	public static Color LeafGreen => ColorTranslator.FromHtml("#5ca904");

	public static Color LightGrey => ColorTranslator.FromHtml("#d8dcd6");

	public static Color Puke => ColorTranslator.FromHtml("#a5a502");

	public static Color PinkishPurple => ColorTranslator.FromHtml("#d648d7");

	public static Color SeaBlue => ColorTranslator.FromHtml("#047495");

	public static Color PalePurple => ColorTranslator.FromHtml("#b790d4");

	public static Color SlateBlue => ColorTranslator.FromHtml("#5b7c99");

	public static Color BlueGrey => ColorTranslator.FromHtml("#607c8e");

	public static Color HunterGreen => ColorTranslator.FromHtml("#0b4008");

	public static Color Fuchsia => ColorTranslator.FromHtml("#ed0dd9");

	public static Color Crimson => ColorTranslator.FromHtml("#8c000f");

	public static Color PaleYellow => ColorTranslator.FromHtml("#ffff84");

	public static Color Ochre => ColorTranslator.FromHtml("#bf9005");

	public static Color MustardYellow => ColorTranslator.FromHtml("#d2bd0a");

	public static Color LightRed => ColorTranslator.FromHtml("#ff474c");

	public static Color Cerulean => ColorTranslator.FromHtml("#0485d1");

	public static Color PalePink => ColorTranslator.FromHtml("#ffcfdc");

	public static Color DeepBlue => ColorTranslator.FromHtml("#040273");

	public static Color Rust => ColorTranslator.FromHtml("#a83c09");

	public static Color LightTeal => ColorTranslator.FromHtml("#90e4c1");

	public static Color Slate => ColorTranslator.FromHtml("#516572");

	public static Color Goldenrod => ColorTranslator.FromHtml("#fac205");

	public static Color DarkYellow => ColorTranslator.FromHtml("#d5b60a");

	public static Color DarkGrey => ColorTranslator.FromHtml("#363737");

	public static Color ArmyGreen => ColorTranslator.FromHtml("#4b5d16");

	public static Color GreyBlue => ColorTranslator.FromHtml("#6b8ba4");

	public static Color Seafoam => ColorTranslator.FromHtml("#80f9ad");

	public static Color Puce => ColorTranslator.FromHtml("#a57e52");

	public static Color SpringGreen => ColorTranslator.FromHtml("#a9f971");

	public static Color DarkOrange => ColorTranslator.FromHtml("#c65102");

	public static Color Sand => ColorTranslator.FromHtml("#e2ca76");

	public static Color PastelGreen => ColorTranslator.FromHtml("#b0ff9d");

	public static Color Mint => ColorTranslator.FromHtml("#9ffeb0");

	public static Color LightOrange => ColorTranslator.FromHtml("#fdaa48");

	public static Color BrightPink => ColorTranslator.FromHtml("#fe01b1");

	public static Color Chartreuse => ColorTranslator.FromHtml("#c1f80a");

	public static Color DeepPurple => ColorTranslator.FromHtml("#36013f");

	public static Color DarkBrown => ColorTranslator.FromHtml("#341c02");

	public static Color Taupe => ColorTranslator.FromHtml("#b9a281");

	public static Color PeaGreen => ColorTranslator.FromHtml("#8eab12");

	public static Color PukeGreen => ColorTranslator.FromHtml("#9aae07");

	public static Color KellyGreen => ColorTranslator.FromHtml("#02ab2e");

	public static Color SeafoamGreen => ColorTranslator.FromHtml("#7af9ab");

	public static Color BlueGreen => ColorTranslator.FromHtml("#137e6d");

	public static Color Khaki => ColorTranslator.FromHtml("#aaa662");

	public static Color Burgundy => ColorTranslator.FromHtml("#610023");

	public static Color DarkTeal => ColorTranslator.FromHtml("#014d4e");

	public static Color BrickRed => ColorTranslator.FromHtml("#8f1402");

	public static Color RoyalPurple => ColorTranslator.FromHtml("#4b006e");

	public static Color Plum => ColorTranslator.FromHtml("#580f41");

	public static Color MintGreen => ColorTranslator.FromHtml("#8fff9f");

	public static Color Gold => ColorTranslator.FromHtml("#dbb40c");

	public static Color BabyBlue => ColorTranslator.FromHtml("#a2cffe");

	public static Color YellowGreen => ColorTranslator.FromHtml("#c0fb2d");

	public static Color BrightPurple => ColorTranslator.FromHtml("#be03fd");

	public static Color DarkRed => ColorTranslator.FromHtml("#840000");

	public static Color PaleBlue => ColorTranslator.FromHtml("#d0fefe");

	public static Color GrassGreen => ColorTranslator.FromHtml("#3f9b0b");

	public static Color Navy => ColorTranslator.FromHtml("#01153e");

	public static Color Aquamarine => ColorTranslator.FromHtml("#04d8b2");

	public static Color BurntOrange => ColorTranslator.FromHtml("#c04e01");

	public static Color NeonGreen => ColorTranslator.FromHtml("#0cff0c");

	public static Color BrightBlue => ColorTranslator.FromHtml("#0165fc");

	public static Color Rose => ColorTranslator.FromHtml("#cf6275");

	public static Color LightPink => ColorTranslator.FromHtml("#ffd1df");

	public static Color Mustard => ColorTranslator.FromHtml("#ceb301");

	public static Color Indigo => ColorTranslator.FromHtml("#380282");

	public static Color Lime => ColorTranslator.FromHtml("#aaff32");

	public static Color SeaGreen => ColorTranslator.FromHtml("#53fca1");

	public static Color Periwinkle => ColorTranslator.FromHtml("#8e82fe");

	public static Color DarkPink => ColorTranslator.FromHtml("#cb416b");

	public static Color OliveGreen => ColorTranslator.FromHtml("#677a04");

	public static Color Peach => ColorTranslator.FromHtml("#ffb07c");

	public static Color PaleGreen => ColorTranslator.FromHtml("#c7fdb5");

	public static Color LightBrown => ColorTranslator.FromHtml("#ad8150");

	public static Color HotPink => ColorTranslator.FromHtml("#ff028d");

	public static Color Black => ColorTranslator.FromHtml("#000000");

	public static Color Lilac => ColorTranslator.FromHtml("#cea2fd");

	public static Color NavyBlue => ColorTranslator.FromHtml("#001146");

	public static Color RoyalBlue => ColorTranslator.FromHtml("#0504aa");

	public static Color Beige => ColorTranslator.FromHtml("#e6daa6");

	public static Color Salmon => ColorTranslator.FromHtml("#ff796c");

	public static Color Olive => ColorTranslator.FromHtml("#6e750e");

	public static Color Maroon => ColorTranslator.FromHtml("#650021");

	public static Color BrightGreen => ColorTranslator.FromHtml("#01ff07");

	public static Color DarkPurple => ColorTranslator.FromHtml("#35063e");

	public static Color Mauve => ColorTranslator.FromHtml("#ae7181");

	public static Color ForestGreen => ColorTranslator.FromHtml("#06470c");

	public static Color Aqua => ColorTranslator.FromHtml("#13eac9");

	public static Color Cyan => ColorTranslator.FromHtml("#00ffff");

	public static Color Tan => ColorTranslator.FromHtml("#d1b26f");

	public static Color DarkBlue => ColorTranslator.FromHtml("#00035b");

	public static Color Lavender => ColorTranslator.FromHtml("#c79fef");

	public static Color Turquoise => ColorTranslator.FromHtml("#06c2ac");

	public static Color DarkGreen => ColorTranslator.FromHtml("#033500");

	public static Color Violet => ColorTranslator.FromHtml("#9a0eea");

	public static Color LightPurple => ColorTranslator.FromHtml("#bf77f6");

	public static Color LimeGreen => ColorTranslator.FromHtml("#89fe05");

	public static Color Grey => ColorTranslator.FromHtml("#929591");

	public static Color SkyBlue => ColorTranslator.FromHtml("#75bbfd");

	public static Color Yellow => ColorTranslator.FromHtml("#ffff14");

	public static Color Magenta => ColorTranslator.FromHtml("#c20078");

	public static Color LightGreen => ColorTranslator.FromHtml("#96f97b");

	public static Color Orange => ColorTranslator.FromHtml("#f97306");

	public static Color Teal => ColorTranslator.FromHtml("#029386");

	public static Color LightBlue => ColorTranslator.FromHtml("#95d0fc");

	public static Color Red => ColorTranslator.FromHtml("#e50000");

	public static Color Brown => ColorTranslator.FromHtml("#653700");

	public static Color Pink => ColorTranslator.FromHtml("#ff81c0");

	public static Color Blue => ColorTranslator.FromHtml("#0343df");

	public static Color Green => ColorTranslator.FromHtml("#15b01a");

	public static Color Purple => ColorTranslator.FromHtml("#7e1e9c");

	public static Color HashMe(string hash, float minrange = 0.5f, float maxrange = 1f)
	{
		if (string.IsNullOrEmpty(hash))
		{
			return Color.white;
		}
		uint num = 1u;
		char[] array = hash.ToCharArray();
		for (int i = 0; (float)i < (float)array.Length * (float)Math.PI && i < 256; i++)
		{
			num *= primes[(int)array[i % array.Length] % primes.Length];
		}
		Color result = AllColors[(long)num % (long)AllColors.Length];
		result.r = Mathf.Lerp(minrange, maxrange, result.r);
		result.g = Mathf.Lerp(minrange, maxrange, result.g);
		result.b = Mathf.Lerp(minrange, maxrange, result.b);
		return result;
	}

	public static Color MoveTowards(Color current, Color target, float maxChannelDelta)
	{
		Color result = current;
		result.r = Mathf.MoveTowards(result.r, target.r, maxChannelDelta);
		result.g = Mathf.MoveTowards(result.g, target.g, maxChannelDelta);
		result.b = Mathf.MoveTowards(result.b, target.b, maxChannelDelta);
		result.a = Mathf.MoveTowards(result.a, target.a, maxChannelDelta);
		return result;
	}
}
