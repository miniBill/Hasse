namespace Hasse.Groups{
	public interface IContainer<in TSub>{
		bool IsSupersetOf(TSub elements);
	}
}
