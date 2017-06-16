/*
 * INTERFACE: REPOSITORY
 * Author: Christian Gonzalez
 * Description: Contract for creating a singleton
 * repository class
 */
using System.Collections.Generic;

public interface IRepository <T> {
	List<T> Contents { get; }
}