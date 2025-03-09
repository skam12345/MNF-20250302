public class PlayerEnum
{
	public enum MODEL_NUMBER_NAME : int
	{
		NONE = 0000,
		Mawang = 0001,
		Buddy01 = 0002,
	};

	public enum MODEL_ANI : int
	{
		IDLE = 0,
		IDLE_WAIT_MOTION,
		WALK,
		RUN,
		JUMP,
		HIT,
		HIT_DOWN,
		FAILED,
		ATTACK,
		SKILL_FIREBALL,
		DIE,
		MAX,
	};

	public static int GetModelNumber(PlayerEnum.MODEL_NUMBER_NAME _target)
	{
		switch (_target)
		{
			case MODEL_NUMBER_NAME.NONE: return 0;
			case MODEL_NUMBER_NAME.Mawang: return 1;
			case MODEL_NUMBER_NAME.Buddy01: return 2;
			default: return -1;
		}
	}

	public static PlayerEnum.MODEL_NUMBER_NAME GetModelEnum(int _index)
	{
		switch (_index)
		{
			case 0: return MODEL_NUMBER_NAME.NONE;
			case 1: return MODEL_NUMBER_NAME.Mawang;
			case 2: return MODEL_NUMBER_NAME.Buddy01;

			default:
				return MODEL_NUMBER_NAME.NONE;
		}
	}
}