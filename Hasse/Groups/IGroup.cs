namespace Hasse.Groups{
	public interface IGroup{
	}

	public interface IGroup<out TSub> : IGroup{
		uint Order{get;}

		TSub Generate(uint index);
	}
}
