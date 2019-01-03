const requestDataType = 'REQUEST_DATA';
const receiveDataType = 'RECEIVE_DATA';
const initialState = { raceData: [], isLoading: false };

export const actionCreators = {
    requestRaceData: () => async (dispatch, getState) => {
        dispatch({ type: requestDataType });

        //const url = `api/SampleData/RaceData`;
        const url = 'https://s3-ap-southeast-2.amazonaws.com/bet-easy-code-challenge/next-to-jump';
        const response = await fetch(url);
        
        const raceDataResults = await response.json();

        dispatch({ type: receiveDataType, raceDataResults });
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === requestDataType) {
        return {
            ...state,
            isLoading: true
        };
    }

    if (action.type === receiveDataType) {
        return {
            ...state,
            raceData: action.raceDataResults.result,
            isLoading: false
        };
    }

    return state;
};
