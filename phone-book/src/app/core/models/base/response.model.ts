/**
 *
 */
export class ResponseModel<T> {
  /**
   *
   */
  result: T;

  /**
   *
   */
  error: any;

  /**
   *
   */
  statusCode: number;
}

export class Success {
  success: boolean;
}
