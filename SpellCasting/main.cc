#include <iostream>
#include <queue>
#include <vector>
#include <cstdlib>

#include "Player.h"
#include "CastSpell.h"
#include "Player.h"
#include "SpellCastingSystem.h"
using namespace std;

int FindNextRandomTarget(int casterid, vector<Player*> &players);
int FindNextRandomSpell(int spellsCount);

int main(int argc, const char * argv[]) {
	SpellCastingSystem* system = new SpellCastingSystem();

	//Add spells, can be as many as needed
	vector<Spell*> spells;
	spells.push_back(new Spell(0, "Spell 1", 15, 60));
	spells.push_back(new Spell(1, "Spell 2", 20, 80));
	spells.push_back(new Spell(2, "Spell 3", 25, 100));
	spells.push_back(new Spell(3, "Spell 4", 30, 120));
	spells.push_back(new Spell(4, "Spell 5", 40, 140));

	//add players, can be as many as needed
	vector<Player*> players;
	players.push_back(new Player("Player 1", 80));
	players.push_back(new Player("Player 2", 70));
	players.push_back(new Player("Player 3", 90));
	players.push_back(new Player("Player 4", 85));
	players.push_back(new Player("Player 5", 75));
	players.push_back(new Player("Player 6", 70));

	//each loop on 1 tick
	long tick = 0;
	srand(time(0));
	do {
		int alives = 0;
		for (unsigned int i = 0; i < players.size(); i++)
			alives += players[i]->IsAlive();

		//if only player is alive, then game over
		if (alives < 2)
			break;

		//Each player has a chance to cast if it's alive.
		for (unsigned int i = 0; i < players.size(); i++) {
			if (players[i]->IsAlive()) {

				//Get a random target to cast
				int targetid = FindNextRandomTarget(i, players);

				//Get a random Spell to use
				int spellid = FindNextRandomSpell(spells.size());

				//Play magic here
				system->SpellCasting(players[i], players[targetid],
						spells[spellid], tick);
			}
		}
		system->Refresh(tick++);
	} while (true);

	//delete players new-ed in heap, otherwise memory leak.
	for (unsigned int i = 0; i < players.size(); i++) {
		if (players[i]->IsAlive())
			cout << "Winner is: " << players[i]->m_name << endl;
		delete players[i];
	}

	//delete spells new-ed in heap, otherwise memory leak.
	for (unsigned int i = 0; i < spells.size(); i++)
		delete spells[i];

	return 0;
}

//Find a next random target to cast spell
//target must be alive and not caster itself
int FindNextRandomTarget(int casterid, vector<Player*> &players) {
	//srand(time(0));
	int targetid = rand() % players.size();
	while (targetid == casterid || !players[targetid]->IsAlive())
		targetid = (targetid + 1) % players.size();
	return targetid;
}

int FindNextRandomSpell(int spellsCount) {
	return rand() % spellsCount;
}

