import { createStore } from 'vuex';

const store = createStore({
  state() {
    return {
      user: null,
      isAuthenticated: false
    };
  },
  mutations: {
    setUser(state, user) {
      state.user = user;
      state.isAuthenticated = true;
    }
  },
  actions: {
    login({ commit }, user) {
      commit('setUser', user);
    }
  },
  getters: {
    isAuthenticated: state => state.isAuthenticated,
    getUser: state => state.user
  }
});

export default store;