/**
 *
 *
 * @export
 * @interface IEntity
 * @template T
 */
export interface IEntity<T> {
  /**
   *
   *
   * @type {T}
   * @memberof IEntity
   */
  id: T;
}

/**
 *
 *
 * @export
 * @abstract
 * @class Entity
 * @implements {IEntity<number>}
 */
export abstract class Entity implements IEntity<number> {
  /**
   *
   *
   * @type {number}
   * @memberof Entity
   */
  id: number;
}
