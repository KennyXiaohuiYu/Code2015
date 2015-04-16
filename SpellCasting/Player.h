#ifndef PLAYER_H
#define PLAYER_H

#include <string>
using namespace std;

//This class is a object of player
//for simplify, only name and Health Point member variables included
//Player is alive only if m_hp > 0;
class Player {
public:
	Player(string name, long hp) {
		m_name = name;
		m_hp = hp;
	}

	/* hit points (health) */
	long m_hp;

	string m_name;

	bool IsAlive() {
		return m_hp > 0;
	}

};

#endif
