import C from '../constants'

export const mood = (state, action) => {
    if(action.type === C.SAVE_MOOD){
        return parseInt(action.payload)
    } else {
        return state
    }
}


