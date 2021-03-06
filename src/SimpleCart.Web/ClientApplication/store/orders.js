export const state = () => ({
  orders: [],
  orderDetail: {
    trackingId: '',
  },
});

export const mutations = {
  setOrders(state, content) {
    state.orders = content;
  },
  setOrderDetails(state, content) {
    state.orderDetail = content;
  },
};

export const actions = {
  async getOrders({ state, commit }, payload) {
    if (!payload.reload) {
      const existingItems = state.orders;
      if (existingItems.length > 0) return;
    }

    const response = await this.$axios.$get('orders');
    if (response.success) {
      commit('setOrders', response.data);
    }
  },
  async getOrderDetails({ state, commit }, payload) {
    const existingItem = state.orderDetail;
    if (existingItem.trackingId === payload.trackingId) return;

    const response = await this.$axios.$get(`orders/${payload.trackingId}`);
    if (response.success) {
      commit('setOrderDetails', response.data);
    }
  },
};
