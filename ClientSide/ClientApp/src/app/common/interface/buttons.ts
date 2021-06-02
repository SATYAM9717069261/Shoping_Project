

export interface mailtop {
    inbox: boolean;
    sent: boolean;
    spam: boolean;
    delete: boolean;
    /** Current button Active Record
     *  if we have 100 buttons on page 
     *  so we can't false each of button just store current active button 
     * and false it
     */
    [current:string]:any;
}