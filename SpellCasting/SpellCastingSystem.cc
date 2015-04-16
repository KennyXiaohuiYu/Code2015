#include <vector>
#include <iostream>
#include <queue>

#include "Spell.h"
#include "CastSpell.h"
#include "Player.h"
#include "SpellCastingSystem.h"
using namespace std;

SpellCastingSystem::SpellCastingSystem() {

}

SpellCastingSystem::~SpellCastingSystem(void) {

}

//Spell Casting action
void SpellCastingSystem::SpellCasting(Player* caster, Player* target,
		Spell* spell, long tick) {
	if (!target->IsAlive()) {
		cout << target->m_name << " already dead, no need to cast." << endl;
		return;
	}

	//Caster can only cast one spell at a time
	if (m_casterList.find(caster) == m_casterList.end()) {

		cout << caster->m_name << " uses " << spell->m_name << " to "
				<< target->m_name << endl;

		//cast spell, and record timeout tick
		CastSpell castspell(caster, target, spell, tick + spell->m_castTime);

		//push to priority queue
		m_castingQueue.push(castspell);

		//add this caster in to this target's casting list map
		AddCaster(target, caster);

		//add caster into player's list who's in casting time
		m_casterList.insert(caster);
	} else {
		//Caster can only cast one spell at a time
		cout << caster->m_name << " in casting time." << endl;
		return;
	}
}

//Status refreshing method
void SpellCastingSystem::Refresh(long tick) {
	cout << "Loop: " << tick << endl;

	//process actions which timeout.
	while (!m_castingQueue.empty()) {

		//Get the nearest due time action
		CastSpell c = m_castingQueue.top();

		//if time is not up then stop
		if (c.m_castTimeoutTick > tick) {
			break;
		}

		//if caster is alive then process, otherwise pop up and go to next action
		if (c.m_caster->IsAlive()) {

			//release caster from casting time players' list
			m_casterList.erase(c.m_caster);

			//if target is not alive, print status
			if (c.m_target->IsAlive()) {
				cout << c.m_target->m_name << " hit for " << c.m_spell->m_damage
						<< " damage!" << endl;
			}

			//record damage
			c.m_target->m_hp -= c.m_spell->m_damage;

			//if target is dead, release all pending spells by releasing all its casters.
			if (!c.m_target->IsAlive()) {
				ReleaseCaster(c.m_target);
				cout << c.m_target->m_name << " is dead." << endl;
			}

		} else {
			cout << "caster is already dead" << endl;

		}

		m_castingQueue.pop();

	}
}

//record who's been targeted, and add caster into caster's list
void SpellCastingSystem::AddCaster(Player* target, Player* caster) {
	if (m_targetList.find(target) == m_targetList.end()) {
		vector<Player*> casters;
		m_targetList[target] = casters;
	}
	m_targetList[target].push_back(caster);

}

//release all casters if target is not alive anymore
void SpellCastingSystem::ReleaseCaster(Player* target) {
	if (m_targetList.find(target) == m_targetList.end()) {
		for (vector<Player*>::iterator it = m_targetList[target].begin();
				it != m_targetList[target].end(); ++it) {
			m_casterList.erase(*it);
		}
		m_targetList[target].clear();
		m_targetList.erase(target);
	}
}
