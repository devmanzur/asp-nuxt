export const state = () => ({
  cart: {
    referenceId: null,
    items: [],
    vat: 0,
    deliveryCharge: 0,
    total: 0,
    discount: 0,
    payable: 0,
  },
});

export const mutations = {
  setCart(state, content) {
    state.cart = content;
  },
  resetCart(state) {
    state.cart = {
      referenceId: null,
      items: [],
      vat: 0,
      deliveryCharge: 0,
      total: 0,
      discount: 0,
      payable: 0,
    };
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
  async setQuantity({ state, commit }, payload) {
    const items = state.cart.items;
    if (items.length <= 0) {
      return;
    }
    const existingItem = items.find(
      (item) => item.productId === payload.productId
    );
    if (existingItem == null) {
      return;
    }

    const updateQuantity = await this.$axios.$put('cart', {
      referenceId: state.cart.referenceId,
      productId: payload.productId,
      quantity: payload.quantity,
    });

    if (updateQuantity.success) {
      commit('setCart', updateQuantity.data);
    }
  },
  async addToCart({ state, commit }, payload) {
    let total = payload.quantity;
    const items = state.cart.items;
    if (items.length > 0) {
      const existingItem = items.find(
        (item) => item.productId === payload.productId
      );
      if (existingItem != null) {
        total += existingItem.quantity;
      }
    }

    const addItemToCart = await this.$axios.$put('cart', {
      referenceId: state.cart.referenceId,
      productId: payload.productId,
      quantity: total,
    });

    if (addItemToCart.success) {
      commit('setCart', addItemToCart.data);
    }
  },
  async checkout({ state, commit }) {
    const items = state.cart.items;
    if (items.length <= 0) {
      return;
    }

    const checkout = await this.$axios.$post('order', {
      referenceId: state.cart.referenceId,
    });
    if (checkout.success) {
      commit('resetCart');
    }
  },
};
