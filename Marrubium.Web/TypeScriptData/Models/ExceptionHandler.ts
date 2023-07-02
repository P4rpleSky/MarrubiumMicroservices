export class ExceptionHandler {
    static handle(exception: Error){
        alert(exception.message)
    }
}