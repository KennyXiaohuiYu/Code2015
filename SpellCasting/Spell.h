#ifndef SPELL_H
#define SPELL_H

#include <string>
using namespace std;

//this class use to represent Spell
//id: an ID of this spell
//name: name of this Spell
//damage: damage to target
//castTime: cast time to caster
class Spell {
public:
	Spell(long id, string name, long damage, long castTime) {
		m_id = id;
		m_name = name;
		m_damage = damage;
		m_castTime = castTime;
	}

	long m_id;
	string m_name;
	long m_castTime;
	long m_damage;
};

#endif
