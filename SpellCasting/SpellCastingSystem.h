#ifndef SPELLCASTINGSYSTEM_H
#define SPELLCASTINGSYSTEM_H

#include <iostream>
#include <queue>
#include <map>
#include <set>
#include "Spell.h"
#include "Player.h"
#include "CastSpell.h"

//comparison method used by priority_queue to sort
//top is the most recent due casting spell.
class TickCompare {
public:
	bool operator()(CastSpell& castSpell1, CastSpell& castSpell2)
	{
		if (castSpell1.m_castTimeoutTick > castSpell2.m_castTimeoutTick)
				return true;
			return false;
	}
};

//Spell Casting System
class SpellCastingSystem {
public:
	SpellCastingSystem();
	virtual ~SpellCastingSystem(void);

	//Spell Casting action
	void SpellCasting(Player* caster, Player* target, Spell* spell, long tick);

	//Status refreshing method
	void Refresh(long tick);

private:
	//a list of players who's in casting
	set<Player*> m_casterList;

	//a map of players who's been targeted, to their casters list.
	map<Player*, vector<Player*> > m_targetList;

	//priority queue to store active casting spells
	priority_queue<CastSpell, vector<CastSpell>, TickCompare> m_castingQueue;

	//record who's been targeted
	void AddCaster(Player* target, Player* caster);

	//release all casters if its target is not alive anymore
	void ReleaseCaster(Player* target);
};

#endif
