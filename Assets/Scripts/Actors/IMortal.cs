/*
 * INTERFACE MORTAL
 * Author: Christian Gonzalez
 * Date Created: 03/03/2017
 * Date Modified: 03/03/2017
 * Description: Interface contract dictating behaviours
 * characters that can die must have.
 */

public interface IMortal : IDamageable {

	void CheckDeath();
	void Kill();
}