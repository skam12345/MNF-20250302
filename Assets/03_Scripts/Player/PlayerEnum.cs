public class PlayerEnum
{
	public enum MODEL_NUMBER_NAME : int
	{
		NONE = 0000,
		MAWANG = 0001,
	};

	public enum MODEL_ANI : byte
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

		MAX,
	};
}