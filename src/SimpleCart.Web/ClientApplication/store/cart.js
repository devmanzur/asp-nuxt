export const state = () => ({
  cart: {
    referenceId: null,
    items: [],
  },
});

export const mutations = {
  setCart(state, content) {
    state.cart = content;
  },
};

export const actions = {
  async initializeCart({ state, commit }) {
    const myCart = state.cart;
    if (myCart.referenceId == null) {
      const refId = '1234567893456789ASAEWE';
      const queryParams = {
        referenceId: refId,
      };
      const getCart = await this.$axios.$get('cart', { params: queryParams });
      if (getCart.success && getCart.data.referenceId != null) {
        commit('setCart', getCart.data);
        return;
      }

      const createCart = await this.$axios.$post('cart', {
        referenceId: refId,
      });
      if (createCart.success) {
        commit('setCart', {
          referenceId: refId,
          items: [],
        });
      }
    }
  },
};
