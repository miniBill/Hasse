SOURCE= AssemblyInfo.cs MyMath.cs Generator.cs \
        Groups/IContainer.cs Groups/ISubGroup.cs \
	Groups/Heavy/Product/ProductElement.cs Groups/Heavy/Product/ProductGroup.cs Groups/Heavy/Product/PowerElement.cs Groups/Heavy/Product/PowerGroup.cs \
	Groups/Heavy/GroupElement.cs Groups/Heavy/Group.cs Groups/Heavy/SubGroup.cs \
	Groups/Heavy/Permutation/SymmetricElement.cs Groups/Heavy/Permutation/SymmetricGroup.cs \
	Groups/IGroup.cs Groups/CalcException.cs \
	Groups/Light/Group.cs Groups/Light/SubGroup.cs Groups/Light/PowerGroup.cs Groups/Light/CyclicGroup.cs \
	GeneratorFactory.cs Main.cs

all: Hasse.exe

hasse-dyn: Hasse.exe
	mkbundle -o $@ $^

hasse: Hasse.exe
	mkbundle --static --deps -o $@ $^

Hasse.exe: $(SOURCE)
	dmcs -r:System -out:$@ $^

.PHONY: clean

clean:
	rm -f Hasse.exe hasse hasse-dyn *.mdb
