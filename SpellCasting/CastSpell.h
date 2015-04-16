#ifndef CASTSPELL_H
#define CASTSPELL_H

#include <string>
using namespace std;

class Spell;
class Player;

//this object represent an action
class CastSpell {
public:
	CastSpell(Player* caster, Player* target, Spell* spell, long castTimeoutTick) {
		m_spell = spell;
		m_castTimeoutTick = castTimeoutTick;
		m_caster = caster;
		m_target = target;
	}

	Spell* m_spell;
	long m_castTimeoutTick;
	Player* m_caster;
	Player* m_target;

};

#endif
